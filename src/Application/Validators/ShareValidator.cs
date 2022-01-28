using System;
using Application.DTOs;
using FluentValidation;
using Globalization;

namespace Application.Validators
{
    public class ShareValidator : AbstractValidator<ShareRequestDto>
    {
        public ShareValidator()
        {
            RuleFor(x => x.DestinationEmail).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Resource.DestinationEmailIsRequired)
                .EmailAddress().WithMessage(Resource.EmailIsInvalid);
            RuleFor(x => x.ContentUrl).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Resource.ContentUrlIsRequired)
                .Must(LinkMustBeAUri).WithMessage(Resource.UrlIsInvalid);
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
