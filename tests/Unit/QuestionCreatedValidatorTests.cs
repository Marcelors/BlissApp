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
    public class QuestionCreatedValidatorTests
    {
        [Fact]
        public void QuestionCreatedValidator_should_is_valid()
        {
            var question = new QuestionCreatedRequestDto
            {
                Choices = new List<string>() { "Apple", "Amazon" },
                ImageUrl = "http://image.com",
                Question = "question test",
                ThumbUrl = "http://thumb.com"
            };

            var validator = new QuestionCreatedValidator();
            var result = validator.Validate(question);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [Theory]
        [ClassData(typeof(QuestionCreatedRequestData))]
        public void QuestionCreatedValidator_should_is_invalid(QuestionCreatedRequestDto question, List<string> errors)
        {
            var validator = new QuestionCreatedValidator();
            var result = validator.Validate(question);

            result.IsValid.Should().BeFalse();
            result.Errors.Select(x => x.ErrorMessage).Should().BeEquivalentTo(errors);
        }

        public class QuestionCreatedRequestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new QuestionCreatedRequestDto
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
                   new QuestionCreatedRequestDto
                    {
                        Choices = new List<string>() { "Apple", "Amazon" },
                        ImageUrl = null,
                        Question = "question test",
                        ThumbUrl = "http://thumb.com"
                    },
                    new[] {Resource.ImageIsRequired}.ToList()
                };
                yield return new object[]
                {
                   new QuestionCreatedRequestDto
                    {
                        Choices = new List<string>() { "Apple", "Amazon" },
                        ImageUrl = "http://image.com",
                        ThumbUrl = "http://thumb.com"
                    },
                    new[] {Resource.QuestionIsRequired}.ToList()
                };
                yield return new object[]
                {
                   new QuestionCreatedRequestDto
                    {
                        Choices = new List<string>() { "Apple", "Amazon" },
                        ImageUrl = "http://image.com",
                        Question = "question test",
                    },
                    new[] {Resource.ThumbIsRequired}.ToList()
                };
                yield return new object[]
                {
                   new QuestionCreatedRequestDto
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
