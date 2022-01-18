using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class QuestionResponseDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }
        public string Question { get; set; }
        public DateTime PublishedAt { get; set; }
        public List<ChoiceResponse> Choices { get; set; } = new();
    }
}
