using System.Collections.Generic;
using System.Linq;
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

        public async Task<(int totalItems, List<Questions> questions)> Get(string filter, int? limit, int? offset)
        {
            var query = _dbset.AsQueryable();

            if (string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Question.Contains(filter));

            var totalItems = await query.CountAsync();

            if (offset.HasValue)
                query = query.Skip(offset.Value);

            if (limit.HasValue)
                query = query.Take(limit.Value);

            var questions = await query.ToListAsync();

            return new (totalItems, questions);

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
