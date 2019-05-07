using Copernicus.Core.Domain.Questions;
using FluentValidation;

namespace Copernicus.Application.Questions.Commands
{
    public class TranslationsValdiator : AbstractValidator<Translations>
    {
        public TranslationsValdiator()
        {
            RuleFor(x => x).NotEmpty().NotNull();
            RuleFor(x => x.Pl).NotEmpty().NotNull();
            RuleFor(x => x.En).NotEmpty().NotNull();
        }
    }
}