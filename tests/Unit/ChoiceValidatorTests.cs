﻿using System.Collections;
using System.Collections.Generic;
using Application.DTOs;
using Application.Validators;
using FluentAssertions;
using Globalization;
using Xunit;

namespace Unit
{
    public class ChoiceValidatorTests
    {
        [Fact]
        public void ChoiceValidator_should_is_valid()
        {
            var choice = new ChoiceRequestDto
            {
                Choice = "Apple",
                Votes = 10
            };

            var validator = new ChoiceValidator();
            var result = validator.Validate(choice);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [Theory]
        [ClassData(typeof(ChoiceRequestData))]
        public void ChoiceValidator_should_is_invalid(ChoiceRequestDto choice, List<string> errors)
        {

            var validator = new ChoiceValidator();
            var result = validator.Validate(choice);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().BeEquivalentTo(errors);
        }

        public class ChoiceRequestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new ChoiceRequestDto
                    {
                        Choice = null,
                        Votes = 0
                    },
                    new[] {Resource.ChoiceIsRequired}
                };
                yield return new object[]
                {
                    new ChoiceRequestDto
                    {
                        Choice = "Apple",
                        Votes = null
                    },
                    new[] {Resource.VotesIsRequired}
                };
                yield return new object[]
                {
                    new ChoiceRequestDto
                    {
                        Choice = null,
                        Votes = null
                    },
                    new[] {Resource.ChoiceIsRequired, Resource.VotesIsRequired}
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
