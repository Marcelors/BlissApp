using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Questions : Entity
    {
        public string ImageUrl { get; private set; }
        public string ThumbUrl { get; private set; }
        public string Question { get; private set; }
        public DateTime PublishedAt { get; private set; }
        public List<Choices> Choices { get; set; } = new();

        private Questions() { }

        public Questions(string question, string imageUrl, string thumbUrl)
        {
            Question = question;
            ImageUrl = imageUrl;
            ThumbUrl = thumbUrl;
            PublishedAt = DateTime.UtcNow;
        }

        public void AddChoices(List<string> choices) => choices.ForEach(choice => Choices.Add(new Choices(choice)));

        public bool ThereWasChange(string question, string imageUrl, string thumbUrl)
        {
            if (question != Question)
                return true;

            if (ImageUrl != imageUrl)
                return true;

            if (ThumbUrl != thumbUrl)
                return true;

            return false;
        }

        public void SetVotes(List<Choices> choicesWithVotes)
        {
            foreach (var item in choicesWithVotes)
            {
                var choice = Choices.FirstOrDefault(x => x.Choice == item.Choice);
                choice?.SetVotes(item.Votes);
            }     
        }
    }
}
