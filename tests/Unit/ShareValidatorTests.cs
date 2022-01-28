using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Validators;
using FluentAssertions;
using Globalization;
using Xunit;

namespace Unit
{
    public class ShareValidatorTests
    {
        [Fact]
        public void ShareValidator_should_is_valid()
        {
            var dto = new ShareRequestDto
            {
                DestinationEmail = "destination@mail.com",
                ContentUrl = "http://localhost.com"
            };

            var validator = new ShareValidator();
            var result = validator.Validate(dto);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [Theory]
        [ClassData(typeof(ShareRequestData))]
        public void ShareValidator_should_is_invalid(ShareRequestDto dto, List<string> errors)
        {

            var validator = new ShareValidator();
            var result = validator.Validate(dto);

            result.IsValid.Should().BeFalse();
            result.Errors.Select(x => x.ErrorMessage).Should().BeEquivalentTo(errors);
        }

        public class ShareRequestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new ShareRequestDto
                    {
                        DestinationEmail = null,
                        ContentUrl = "http://localhost.com"
                    },
                    new[] {Resource.DestinationEmailIsRequired}.ToList()
                };
                yield return new object[]
                {
                   new ShareRequestDto
                    {
                        DestinationEmail = "destination@mail.com",
                        ContentUrl = null
                    },
                    new[] {Resource.ContentUrlIsRequired}.ToList()
                };
                yield return new object[]
                {
                    new ShareRequestDto
                    {
                        DestinationEmail = "teste",
                        ContentUrl = "http://localhost.com"
                    },
                    new[] {Resource.EmailIsInvalid}.ToList()
                };
                yield return new object[]
                {
                    new ShareRequestDto
                    {
                        DestinationEmail = "destination@mail.com",
                        ContentUrl = "localhost"
                    },
                    new[] {Resource.UrlIsInvalid}.ToList()
                };
                yield return new object[]
                {
                    new ShareRequestDto
                    {
                        DestinationEmail = null,
                        ContentUrl = null
                    },
                    new[] {Resource.DestinationEmailIsRequired, Resource.ContentUrlIsRequired}.ToList()
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
