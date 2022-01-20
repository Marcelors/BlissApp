using System;
using Application.DTOs;
using FluentValidation;
using Globalization;

namespace Application.Validators
{
    public class QuestionCreatedValidator : AbstractValidator<QuestionCreatedRequestDto>
    {
        public QuestionCreatedValidator()
        {
            RuleFor(x => x.Question).NotEmpty(Resource.QuestionIsRequired);
            RuleFor(x => x.ImageUrl).NotEmpty(Resource.ImageIsRequired);
            RuleFor(x => x.ThumbUrl).NotEmpty(Resource.ThumbIsRequired);
        }
    }
}
