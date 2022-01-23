using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;

namespace Application
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionResponseDto> Add(QuestionCreatedRequestDto dto)
        {
            var question = new Questions(dto.Question, dto.ImageUrl, dto.ThumbUrl);
            question.AddChoices(dto.Choices);

            await _questionRepository.Add(question);

            return question;
        }

        public async Task<PaginatedQuestionResponseDto> Get(FilterDto filter)
        {
            var (totalItems, questions) = await _questionRepository.Get(filter.Filter, filter.Offset, filter.Limit);
            return new PaginatedQuestionResponseDto
            {
                TotalItems = totalItems,
                Questions = questions.Select(question => (QuestionResponseDto) question).ToList()
            };
        }

        public async Task<QuestionResponseDto> GetById(int id)
        {
            var question = await _questionRepository.GetById(id);
            return question;
        }

        public Task<QuestionUpdatedRequestDto> Update(int id, QuestionUpdatedRequestDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
