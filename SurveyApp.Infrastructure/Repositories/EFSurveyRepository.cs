using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFSurveyRepository : EFBaseRepository<SurveyDbContext, Survey>, ISurveyRepository
    {
        public EFSurveyRepository(SurveyDbContext context) : base(context)
        {
        }
    }
}
