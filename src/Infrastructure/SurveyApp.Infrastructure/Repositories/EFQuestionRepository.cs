using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFQuestionRepository : EFBaseRepository<SurveyDbContext, Question>, IQuestionRepository
    {
        private readonly SurveyDbContext _context;
        public EFQuestionRepository(SurveyDbContext context) : base(context)
        {
            _context = context;
        }

        public override IList<Question> GetAll()
        {
            return _context.Questions.AsNoTracking()
                                   .Include(q => q.QuestionOptions)
                                   .Include(q => q.QuestionType)
                                   .ToList();
        }

        public async override Task<IList<Question>> GetAllAsync()
        {
            return await _context.Questions.AsNoTracking()
                                   .Include(q => q.QuestionOptions)
                                   .Include(q => q.QuestionType)
                                         .ToListAsync();
        }
    }
}
