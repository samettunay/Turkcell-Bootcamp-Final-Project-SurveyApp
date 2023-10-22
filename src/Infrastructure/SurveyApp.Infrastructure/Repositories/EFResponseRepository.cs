using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFResponseRepository : EFBaseRepository<SurveyDbContext, Response>, IResponseRepository
    {
        private readonly SurveyDbContext _context;
        public EFResponseRepository(SurveyDbContext context) : base(context)
        {
            _context = context;
        }

        public override IList<Response> GetAll()
        {
            return _context.Responses.AsNoTracking()
                                     .Include(r => r.Answers)
                                     .ThenInclude(a => a.AnswerOptions)
                                     .ThenInclude(ao => ao.QuestionOption)
                                     .Include(r => r.Answers)
                                     .ThenInclude(a => a.Question)
                                     .Include(r => r.Survey)
                                     .ToList();
        }

        public async override Task<IList<Response>> GetAllAsync()
        {
            return await _context.Responses.AsNoTracking()
                                           .Include(r => r.Answers)
                                           .ThenInclude(a => a.AnswerOptions)
                                           .ThenInclude(ao => ao.QuestionOption)
                                           .Include(r => r.Answers)
                                           .ThenInclude(a => a.Question)
                                           .Include(r => r.Survey)
                                           .ToListAsync();
        }
    }
}
