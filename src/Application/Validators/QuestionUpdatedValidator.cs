using Application.DTOs;
using FluentValidation;
using Globalization;

namespace Application.Validators
{
    public class QuestionUpdatedValidator : AbstractValidator<QuestionUpdatedRequestDto>
    {
        public QuestionUpdatedValidator()
        {
            RuleFor(x => x.Question).NotEmpty().WithMessage(Resource.QuestionIsRequired);
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage(Resource.ImageIsRequired);
            RuleFor(x => x.ThumbUrl).NotEmpty().WithMessage(Resource.ThumbIsRequired);
            RuleFor(x => x.Choices).NotEmpty().WithMessage(Resource.ChoicesIsRequired);
        }
    }
}
