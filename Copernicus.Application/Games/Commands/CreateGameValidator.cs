using FluentValidation;

namespace Copernicus.Application.Games.Commands
{
    public class CreateGameValidator : AbstractValidator<CreateGame>
    {
        public CreateGameValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.MaxQuestions)
                .NotNull()
                .GreaterThanOrEqualTo(5)
                .LessThanOrEqualTo(25);
            RuleFor(x => x.PrimaryLanguage)
                .NotNull()
                .NotEmpty()
                .Must(x => x == "PL" || x == "EN");
        }
    }
}
