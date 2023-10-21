using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFAnswerRepository : EFBaseRepository<SurveyDbContext, Answer>, IAnswerRepository
    {
        private readonly SurveyDbContext _context;
        public EFAnswerRepository(SurveyDbContext context) : base(context)
        {
            _context = context;
        }

        public override IList<Answer> GetAll()
        {
            return _context.Answers.AsNoTracking()
                                   .Include(a => a.AnswerOptions)
                                   .ThenInclude(ao => ao.QuestionOption)
                                   .Include(a => a.Question)
                                   .ToList();
        }

        public async override Task<IList<Answer>> GetAllAsync()
        {
            return await _context.Answers.AsNoTracking()
                                   .Include(a => a.AnswerOptions)
                                   .ThenInclude(ao => ao.QuestionOption)
                                   .Include(a => a.Question)
                                   .ToListAsync();
        }
    }
}
