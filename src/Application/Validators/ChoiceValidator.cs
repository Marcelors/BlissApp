using Application.DTOs;
using FluentValidation;
using Globalization;

namespace Application.Validators
{
    public class ChoiceValidator : AbstractValidator<ChoiceRequestDto>
    {
        public ChoiceValidator()
        {
            RuleFor(x => x.Choice).NotEmpty().WithMessage(Resource.ChoiceIsRequired);
            RuleFor(x => x.Votes).NotNull().WithMessage(Resource.VotesIsRequired);
        }
    }
}
