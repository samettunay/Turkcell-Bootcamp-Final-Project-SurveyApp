using Microsoft.EntityFrameworkCore;
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
        private readonly SurveyDbContext _context;
        public EFSurveyRepository(SurveyDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<bool> IsExistsAsync(int id)
        {
            return _context.Surveys.AnyAsync(s => s.Id == id);
        }

        public async Task<IList<Survey>> GetSurveysByTypeIdAsync(int surveyTypeId)
        {
            return await _context.Surveys.Where(s => s.SurveyTypeId == surveyTypeId)
                                   .ToListAsync();
        }

        public override async Task<Survey> GetByIdAsync(int id)
        {
            return await _context.Surveys.Include(s => s.Questions)
                                         .ThenInclude(q => q.QuestionOptions)
                                         .Include(s => s.Questions)
                                         .ThenInclude(q => q.QuestionType)
                                         .SingleOrDefaultAsync(s => s.Id == id);
        }

        public override IList<Survey> GetAll()
        {
            return _context.Surveys.AsNoTracking()
                                   .Include(s => s.Questions)
                                   .ThenInclude(q => q.QuestionOptions)
                                   .Include(s => s.Questions)
                                   .ThenInclude(q => q.QuestionType)
                                   .ToList();
        }

        public async override Task<IList<Survey>> GetAllAsync()
        {
            return await _context.Surveys.AsNoTracking()
                                         .Include(s => s.Questions)
                                         .ThenInclude(q => q.QuestionOptions)
                                         .Include(s => s.Questions)
                                         .ThenInclude(q => q.QuestionType)
                                         .ToListAsync();
        }
    }
}
