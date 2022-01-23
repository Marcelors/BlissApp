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

    }
}
