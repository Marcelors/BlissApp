using System.Threading.Tasks;
using Application.DTOs;

namespace Application
{
    public interface IQuestionService
    {
        Task<QuestionResponseDto> Add(QuestionCreatedRequestDto dto);
        Task<QuestionUpdatedRequestDto> Update(int id, QuestionUpdatedRequestDto dto);
        Task<QuestionResponseDto> GetById(int id);
        Task<PaginatedQuestionResponseDto> Get(FilterDto filter);
    }
}
