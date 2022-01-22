using System.Collections.Generic;

namespace Application.DTOs
{
    public class PaginatedQuestionResponseDto
    {
        public int TotalItems { get; set; }
        public List<QuestionResponseDto> Questions { get; set; } = new();
    }
}
