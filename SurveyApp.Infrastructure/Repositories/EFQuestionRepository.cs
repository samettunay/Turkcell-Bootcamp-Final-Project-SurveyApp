using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFQuestionRepository : EFBaseRepository<SurveyDbContext, Question>, IQuestionRepository
    {
        public EFQuestionRepository(SurveyDbContext context) : base(context)
        {
        }
    }
}
