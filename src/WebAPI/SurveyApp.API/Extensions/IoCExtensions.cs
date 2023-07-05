using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Infrastructure.Data;
using SurveyApp.Infrastructure.Repositories;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<ISurveyRepository, EFSurveyRepository>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IResponseRepository, EFResponseRepository>();

            services.AddDbContext<SurveyDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
