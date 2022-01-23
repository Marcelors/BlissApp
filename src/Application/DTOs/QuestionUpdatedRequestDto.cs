using System.Collections.Generic;

namespace Application.DTOs
{
    public class QuestionUpdatedRequestDto
    {
        public string Question { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }
        public List<ChoiceRequestDto> Choices { get; set; } = new();
    }
}
