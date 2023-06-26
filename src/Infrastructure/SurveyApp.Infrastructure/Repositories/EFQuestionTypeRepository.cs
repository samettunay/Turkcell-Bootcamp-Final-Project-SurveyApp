using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFQuestionTypeRepository : EFBaseRepository<SurveyDbContext, QuestionType>, IQuestionTypeRepository
    {
        public EFQuestionTypeRepository(SurveyDbContext context) : base(context)
        {
        }
    }
}
