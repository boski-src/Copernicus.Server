using System.Threading.Tasks;
using Copernicus.Application.Questions.Commands;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Questions.Handlers
{
    public class DeleteQuestionHandler : ICommandHandler<DeleteQuestion>
    {
        private readonly IQuestionService _questionService;

        public DeleteQuestionHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task Handle(DeleteQuestion command)
        {
            await _questionService.Delete(command.Id);
        }
    }
}