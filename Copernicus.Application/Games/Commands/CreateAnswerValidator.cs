using FluentValidation;

namespace Copernicus.Application.Games.Commands
{
    public class CreateAnswerValidator : AbstractValidator<CreateAnswer>
    {
        public CreateAnswerValidator()
        {
            RuleFor(x => x.QuestionId).NotNull().NotEmpty();
            RuleFor(x => x.Answer).NotNull().NotEmpty();
        }
    }
}