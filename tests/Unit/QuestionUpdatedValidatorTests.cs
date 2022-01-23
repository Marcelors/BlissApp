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
    public class QuestionUpdatedValidatorTests
    {
        [Fact]
        public void QuestionUpdatedValidator_should_is_valid()
        {
            var question = new QuestionUpdatedRequestDto
            {
                Choices = new List<ChoiceRequestDto>() {
                    new() {Choice = "Apple", Votes = 10},
                    new() {Choice = "Amazon", Votes = 30},
                },
                ImageUrl = "http://image.com",
                Question = "question test",
                ThumbUrl = "http://thumb.com"
            };

            var validator = new QuestionUpdatedValidator();
            var result = validator.Validate(question);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [Theory]
        [ClassData(typeof(QuestionUpdatedRequestData))]
        public void QuestionUpdatedValidator_should_is_invalid(QuestionUpdatedRequestDto question, List<string> errors)
        {
            var validator = new QuestionUpdatedValidator();
            var result = validator.Validate(question);

            result.IsValid.Should().BeFalse();
            result.Errors.Select(x => x.ErrorMessage).Should().BeEquivalentTo(errors);
        }

        public class QuestionUpdatedRequestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new QuestionUpdatedRequestDto
                    {
                        Choices = null,
                        ImageUrl = "http://image.com",
                        Question = "question test",
                        ThumbUrl = "http://thumb.com"
                    },
                    new[] {Resource.ChoicesIsRequired}.ToList()
                };
                yield return new object[]
                {
                   new QuestionUpdatedRequestDto
                    {
                        Choices = new List<ChoiceRequestDto>() {
                            new() {Choice = "Apple", Votes = 10},
                            new() {Choice = "Amazon", Votes = 30},
                        },
                        ImageUrl = null,
                        Question = "question test",
                        ThumbUrl = "http://thumb.com"
                    },
                    new[] {Resource.ImageIsRequired}.ToList()
                };
                yield return new object[]
                {
                   new QuestionUpdatedRequestDto
                    {
                        Choices = new List<ChoiceRequestDto>() {
                            new() {Choice = "Apple", Votes = 10},
                            new() {Choice = "Amazon", Votes = 30},
                        },
                        ImageUrl = "http://image.com",
                        ThumbUrl = "http://thumb.com"
                    },
                    new[] {Resource.QuestionIsRequired}
                };
                yield return new object[]
                {
                   new QuestionUpdatedRequestDto
                    {
                        Choices = new List<ChoiceRequestDto>() {
                            new() {Choice = "Apple", Votes = 10},
                            new() {Choice = "Amazon", Votes = 30},
                        },
                        ImageUrl = "http://image.com",
                        Question = "question test",
                    },
                    new[] {Resource.ThumbIsRequired}.ToList()
                };
                yield return new object[]
                {
                   new QuestionUpdatedRequestDto
                    {
                        Choices = null,
                        ImageUrl = null,
                        Question = null,
                        ThumbUrl = null
                    },
                    new[] {Resource.ChoiceIsRequired, Resource.ImageIsRequired, Resource.QuestionIsRequired, Resource.ThumbIsRequired}.ToList()
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
