using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Games
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;

        public GameService(IGameRepository gameRepository,
            IUserRepository userRepository,
            IQuestionRepository questionRepository)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            _questionRepository = questionRepository;
        }

        public async Task Create(Guid id, Guid userId, string name, string primaryLanguage, int maxQuestions = 10)
        {
            var game = await _gameRepository.FindOne(id);
            if (game != null)
                throw new GameServiceExceptions.AlreadyExists();

            var code = new Random().Next(1000000, 9999999).ToString();
            game = await _gameRepository.FindOneByCode(code);
            if (game != null)
                throw new GameServiceExceptions.AlreadyExists();

            var user = await _userRepository.FindOne(userId);
            var questions = await _questionRepository.FindManyRandom(maxQuestions);

            var newGame = new Game(id, name, primaryLanguage, code, user.Id, user.Name, user.AvatarUrl);
            foreach (var q in questions.Select((value, index) => new { value, index }).ToList())
            {
                newGame.AddQuestion(GameQuestion.FromInstance(q.value, q.index));
            }

            await _gameRepository.Create(newGame);
        }

        public async Task Start(Guid id, Guid userId)
        {
            var game = await GetGameAndCheckOwnership(id, userId);

            game.Start();

            await _gameRepository.Update(game);
            // todo GameStartedEvent
        }

        public async Task End(Guid id, Guid userId)
        {
            var game = await GetGameAndCheckOwnership(id, userId);

            game.End();

            await _gameRepository.Update(game);
        }

        public async Task LeaderboardCalculate(Guid id)
        {
            var game = await _gameRepository.FindOne(id);
            var leaderboard = new Leaderboard();

            var answers = game.Answers.Where(x => x.IsCorrect).ToImmutableList();
            var players = answers.GroupBy(x => x.UserId).Select(x => x.First());
            var tempWinners = new HashSet<Winner>();

            foreach (var player in players)
            {
                var playerAnswers = answers.Count(x => x.UserId == player.UserId);
                tempWinners.Add(new Winner(player.UserId, player.UserName, playerAnswers));
            }

            var sortedWinners = tempWinners.OrderByDescending(x => x.Score);
            foreach (var winner in sortedWinners)
            {
                leaderboard.AddWinner(winner);
            }

            game.SetLeaderboard(leaderboard);
            await _gameRepository.Update(game);
        }

        public async Task Join(Guid id, Guid userId)
        {
            var game = await _gameRepository.FindOne(id);
            if (game == null)
                throw new GameServiceExceptions.NotFound();

            var user = await _userRepository.FindOne(userId);
            game.AddMember(Member.Create(user.Id, user.Name, user.AvatarUrl));

            await _gameRepository.Update(game);
        }

        public async Task Leave(Guid id, Guid userId)
        {
            var game = await GetGameAndCheckMembership(id, userId);

            var user = await _userRepository.FindOne(userId);

            var isCreator = game.Members.First(x => x.UserId == user.Id).IsCreator;

            if (isCreator)
            {
                game.RemoveMember(Member.CreateFromCreator(user.Id, user.Name, user.AvatarUrl));
                game.End();
            }
            else
            {
                game.RemoveMember(Member.Create(user.Id, user.Name, user.AvatarUrl));
            }

            await _gameRepository.Update(game);
        }

        public async Task<Answer> CreateAnswer(Guid id, Guid questionId, Guid userId, string answerValue)
        {
            var game = await GetGameAndCheckMembership(id, userId);

            if (questionId != game.CurrentQuestionId)
                throw new GameServiceExceptions.AnswerSequenceInvalid();

            var existingAnswer = game.Answers
                                     .Where(x => x.QuestionId == questionId)
                                     .FirstOrDefault(x => x.UserId == userId);
            
            if (existingAnswer != null)
                throw new GameServiceExceptions.AlreadyAnswered();

            var question = game.Questions.First(x => x.Id == questionId);

            var user = await _userRepository.FindOne(userId);
            var answer = new Answer(
                questionId,
                userId,
                user.Name,
                answerValue,
                question.ValidateAnswer(answerValue)
            );

            game.AddAnswer(answer);

            await _gameRepository.Update(game);

            return answer;
        }

        public async Task<Guid> NextQuestion(Guid id, Guid userId)
        {
            var game = await GetGameAndCheckOwnership(id, userId);

            var nextOrderIndex = 0;

            var question = game.Questions.FirstOrDefault(x => x.Id == game.CurrentQuestionId);
            if (question != null) nextOrderIndex = question.OrderIndex + 1;

            var nextQuestion = game.Questions.FirstOrDefault(x => x.OrderIndex == nextOrderIndex);

            if (nextQuestion == null)
                throw new GameServiceExceptions.NoMoreQuestions();

            game.SetCurrentQuestion(nextQuestion.Id);

            await _gameRepository.Update(game);

            return nextQuestion.Id;
        }

        private async Task<Game> GetGameAndCheckOwnership(Guid id, Guid userId)
        {
            var game = await _gameRepository.FindOne(id);
            if (game == null)
                throw new GameServiceExceptions.NotFound();

            if (!game.Members.First(x => x.UserId == userId).IsCreator)
                throw new GameServiceExceptions.NotCreator();

            return game;
        }

        private async Task<Game> GetGameAndCheckMembership(Guid id, Guid userId)
        {
            var game = await _gameRepository.FindOne(id);
            if (game == null)
                throw new GameServiceExceptions.NotFound();

            if (game.Members.FirstOrDefault(x => x.UserId == userId) == null)
                throw new GameServiceExceptions.NotMember();

            return game;
        }
    }
}
