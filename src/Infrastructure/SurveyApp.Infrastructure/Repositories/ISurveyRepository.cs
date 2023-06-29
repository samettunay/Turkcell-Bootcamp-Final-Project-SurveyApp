using SurveyApp.Entities;

namespace SurveyApp.Infrastructure.Repositories
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        Task<bool> IsExistsAsync(int id);
    }
}
