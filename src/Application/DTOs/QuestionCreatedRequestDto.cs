using System.Collections.Generic;

namespace Application.DTOs
{
    public class QuestionCreatedRequestDto
    {
        public string Question { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }
        public List<string> Choices { get; set; } = new();
    }
}
