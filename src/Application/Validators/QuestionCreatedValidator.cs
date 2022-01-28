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
            RuleFor(x => x.Question).NotEmpty().WithMessage(Resource.QuestionIsRequired);
            RuleFor(x => x.ImageUrl).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Resource.ImageIsRequired)
                .Must(LinkMustBeAUri).WithMessage(Resource.UrlIsInvalid);
            RuleFor(x => x.ThumbUrl).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Resource.ThumbIsRequired)
                .Must(LinkMustBeAUri).WithMessage(Resource.UrlIsInvalid);
            RuleFor(x => x.Choices).NotEmpty().WithMessage(Resource.ChoicesIsRequired);
        }

        private static bool LinkMustBeAUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
