using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFAnswerOptionRepository : EFBaseRepository<SurveyDbContext, AnswerOption>, IAnswerOptionRepository
    {
        public EFAnswerOptionRepository(SurveyDbContext context) : base(context)
        {
        }
    }
}
