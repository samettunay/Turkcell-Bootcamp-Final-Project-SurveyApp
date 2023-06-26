using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFAnswerRepository : EFBaseRepository<SurveyDbContext, Answer>, IAnswerRepository
    {
        public EFAnswerRepository(SurveyDbContext context) : base(context)
        {
        }
    }
}
