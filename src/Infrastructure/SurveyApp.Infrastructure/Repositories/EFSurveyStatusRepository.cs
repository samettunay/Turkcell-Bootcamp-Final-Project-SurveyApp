using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFSurveyStatusRepository : EFBaseRepository<SurveyDbContext, SurveyStatus>, ISurveyStatusRepository
    {
        public EFSurveyStatusRepository(SurveyDbContext context) : base(context)
        {
        }
    }
}
