using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Unit
{
    public class QuestionsTests
    {
        [Fact]
        public void AddChoices_should_add_the_choices()
        {
            var question = new Questions("question test", "http://image.com", "http://thumb.com");

            var choices = new[] { "Apple", "Microsoft", "Amazon" };

            var expected = new List<Choices>
            {
                new("Apple"),
                new("Microsoft"),
                new("Amazon"),
            };

            question.AddChoices(choices.ToList());

            question.Choices.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("question test1", "http://image.com", "http://thumb.com")]
        [InlineData("question test", "http://image1.com", "http://thumb.com")]
        [InlineData("question test", "http://image.com", "http://thumb1.com")]
        public void ThereWasChange_should_returns_true(string question, string imageUrl, string thumbUrl)
        {
            var existingQuestion = new Questions("question test", "http://image.com", "http://thumb.com");

            var result = existingQuestion.ThereWasChange(question, imageUrl, thumbUrl);

            result.Should().BeTrue();
        }

        [Fact]
        public void ThereWasChange_should_returns_false()
        {
            const string question = "question test";
            const string imageUrl = "http://image.com";
            const string thumbUrl = "http://thumb.com";

            var existingQuestion = new Questions("question test", "http://image.com", "http://thumb.com");

            var result = existingQuestion.ThereWasChange(question, imageUrl, thumbUrl);

            result.Should().BeFalse();
        }

        [Fact]
        public void SetVotes_should_add_votes_in_choices()
        {
            var question = new Questions("question test", "http://image.com", "http://thumb.com");
            var choices = new[] { "Apple", "Microsoft", "Amazon" };
            question.AddChoices(choices.ToList());

            var choicesWithVotes = new List<Choices>
            {
                new Choices("Apple", 10),
                new Choices("Microsoft", 20),
                new Choices("Amazon", 30)
            };

            question.SetVotes(choicesWithVotes);

            question.Choices.Should().BeEquivalentTo(choicesWithVotes);
        }

        [Fact]
        public void SetVotes_should_not_add_votes_in_choices()
        {
            var question = new Questions("question test", "http://image.com", "http://thumb.com");
            var choices = new[] { "Apple", "Microsoft", "Amazon" };
            question.AddChoices(choices.ToList());

            var choicesWithVotes = new List<Choices>
            {
                new Choices("Sony", 10),
                new Choices("Nike", 20),
                new Choices("Coca", 30)
            };

            var expected = new List<Choices>
            {
                new("Apple"),
                new("Microsoft"),
                new("Amazon"),
            };

            question.SetVotes(choicesWithVotes);

            question.Choices.Should().BeEquivalentTo(expected);
        }
    }
}
