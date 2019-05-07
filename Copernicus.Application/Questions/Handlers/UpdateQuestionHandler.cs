using System.Threading.Tasks;
using Copernicus.Application.Questions.Commands;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Questions.Handlers
{
    public class UpdateQuestionHandler : ICommandHandler<UpdateQuestion>
    {
        private readonly IQuestionService _questionService;

        public UpdateQuestionHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task Handle(UpdateQuestion command)
        {
            await _questionService.Update(
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