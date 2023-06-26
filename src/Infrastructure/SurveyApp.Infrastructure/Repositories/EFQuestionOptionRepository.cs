using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFQuestionOptionRepository : EFBaseRepository<SurveyDbContext, QuestionOption>, IQuestionOptionRepository
    {
        public EFQuestionOptionRepository(SurveyDbContext context) : base(context)
        {
        }
    }
}
