using Domain.Entities;

namespace Domain.Repositories
{
    public interface IQuestionRepository
    {
        public void Add(Questions question);
        public void Update(Questions question);
        public Questions GetById(int id);
    }
}
