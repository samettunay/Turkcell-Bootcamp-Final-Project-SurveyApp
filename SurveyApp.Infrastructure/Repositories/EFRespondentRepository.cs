using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFRespondentRepository : EFBaseRepository<SurveyDbContext, Respondent>, IRespondentRepository
    {
        public EFRespondentRepository(SurveyDbContext context) : base(context)
        {
        }
    }
}
