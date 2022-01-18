using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IQuestionRepository
    {
        public Task Add(Questions question);
        public Task Update(Questions question);
        public Task<Questions> GetById(int id);
    }
}
