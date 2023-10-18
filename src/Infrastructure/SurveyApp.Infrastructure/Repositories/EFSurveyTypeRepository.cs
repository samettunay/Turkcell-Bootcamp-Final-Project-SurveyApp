using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFSurveyTypeRepository : EFBaseRepository<SurveyDbContext, SurveyType>, ISurveyTypeRepository
    {
        private readonly SurveyDbContext _context;

        public EFSurveyTypeRepository(SurveyDbContext context) : base(context)
        {
            _context = context;
        }
        public override IList<SurveyType> GetAll()
        {
            return _context.SurveyTypes.AsNoTracking()
                                       .Include(st => st.Surveys)
                                       .ToList();
        }

        public async override Task<IList<SurveyType>> GetAllAsync()
        {
            return await _context.SurveyTypes.AsNoTracking()
                                             .Include(st => st.Surveys)
                                             .ToListAsync();
        }
    }
}
