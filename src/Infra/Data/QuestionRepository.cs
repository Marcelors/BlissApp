using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly Context _context;
        private DbSet<Questions> _dbset;

        public QuestionRepository(Context context)
        {
            _context = context;
            _dbset = _context.Set<Questions>();
        }

        public async Task Add(Questions question)
        {
            await _dbset.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public Task<Questions> GetById(int id)
        {
            return _dbset.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Questions question)
        {
            _dbset.Update(question);
            await _context.SaveChangesAsync();
        }
    }
}
