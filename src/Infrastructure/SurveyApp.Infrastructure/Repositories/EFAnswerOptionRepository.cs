using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFAnswerOptionRepository : EFBaseRepository<SurveyDbContext, AnswerOption>, IAnswerOptionRepository
    {
        private readonly SurveyDbContext _context;
        public EFAnswerOptionRepository(SurveyDbContext context) : base(context)
        {
            _context = context;
        }

        public override IList<AnswerOption> GetAll()
        {
            return _context.AnswerOptions.AsNoTracking()
                                   .Include(ao => ao.QuestionOption)
                                   .Include(ao => ao.Answer)
                                   .ToList();
        }

        public async override Task<IList<AnswerOption>> GetAllAsync()
        {
            return await _context.AnswerOptions.AsNoTracking()
                                         .Include(ao => ao.QuestionOption)
                                         .Include(ao => ao.Answer)
                                         .ToListAsync();
        }
    }
}
