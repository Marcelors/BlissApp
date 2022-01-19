using System.Threading.Tasks;
using Application.DTOs;

namespace Application
{
    public interface IQuestionService
    {
        public Task<QuestionResponseDto> Add(QuestionCreatedRequestDto dto);
        public Task<QuestionUpdatedRequestDto> Update(int id, QuestionUpdatedRequestDto dto);
        public Task<QuestionResponseDto> GetById(int id);
    }
}
