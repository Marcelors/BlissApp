using System;
using System.Collections.Generic;

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
    }
}
