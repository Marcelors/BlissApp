using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IQuestionRepository
    {
        Task Add(Questions question);
        Task Update(Questions question);
        Task<Questions> GetById(int id);
        Task<(int totalItems, List<Questions> questions)> Get(string filter, int? limit, int? offset);
    }
}
