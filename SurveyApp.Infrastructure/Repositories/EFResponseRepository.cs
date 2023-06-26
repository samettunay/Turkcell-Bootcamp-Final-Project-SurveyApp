using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFResponseRepository : EFBaseRepository<SurveyDbContext, Response>, IResponseRepository
    {
        public EFResponseRepository(SurveyDbContext context) : base(context)
        {
        }
    }
}
