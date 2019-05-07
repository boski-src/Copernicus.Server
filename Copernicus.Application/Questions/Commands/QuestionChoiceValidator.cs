using Copernicus.Core.Domain.Questions;
using FluentValidation;

namespace Copernicus.Application.Questions.Commands
{
    public class QuestionChoiceValidator : AbstractValidator<Choice>
    {
        public QuestionChoiceValidator()
        {
            RuleFor(x => x.Answer).NotEmpty().NotNull();
            RuleFor(x => x.IsCorrect).NotNull();
            RuleFor(x => x.Translations).NotEmpty().NotNull();
            RuleFor(x => x.Translations.Pl).NotEmpty().NotNull();
            RuleFor(x => x.Translations.En).NotEmpty().NotNull();
        }
    }
}