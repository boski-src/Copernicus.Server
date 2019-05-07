using FluentValidation;

namespace Copernicus.Application.Questions.Commands
{
    public class CreateQuestionValidator : AbstractValidator<CreateQuestion>
    {
        public CreateQuestionValidator()
        {
            RuleFor(x => x.Query).NotEmpty().NotNull();
            RuleFor(x => x.Time).GreaterThanOrEqualTo(10000);
            RuleFor(x => x.Choices).Must(x => x.Count >= 2 && x.Count <= 6);
            RuleForEach(x => x.Choices).SetValidator(new QuestionChoiceValidator());
            RuleFor(x => x.Translations).SetValidator(new TranslationsValdiator());
        }
    }
}
