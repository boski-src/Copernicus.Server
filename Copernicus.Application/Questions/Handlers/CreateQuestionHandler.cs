using System.Threading.Tasks;
using Copernicus.Application.Questions.Commands;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Questions.Handlers
{
    public class CreateQuestionHandler : ICommandHandler<CreateQuestion>
    {
        private readonly IQuestionService _questionService;

        public CreateQuestionHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task Handle(CreateQuestion command)
        {
            await _questionService.Create(
                command.Id,
                command.Query,
                command.Image,
                command.Time,
                command.Choices,
                command.Translations
            );
        }
    }
}