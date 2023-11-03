using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Infrastructure.Data;
using SurveyApp.Infrastructure.Repositories;
using SurveyApp.Services.Services;

namespace SurveyApp.Mvc.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<ISurveyRepository, EFSurveyRepository>();
            services.AddScoped<ISurveyStatusService, SurveyStatusService>();
            services.AddScoped<ISurveyStatusRepository, EFSurveyStatusRepository>();
            services.AddScoped<ISurveyTypeService, SurveyTypeService>();
            services.AddScoped<ISurveyTypeRepository, EFSurveyTypeRepository>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IAnswerRepository, EFAnswerRepository>();
            services.AddScoped<IAnswerOptionService, AnswerOptionService>();
            services.AddScoped<IAnswerOptionRepository, EFAnswerOptionRepository>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IResponseRepository, EFResponseRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionRepository, EFQuestionRepository>();
            services.AddScoped<IQuestionTypeService, QuestionTypeService>();
            services.AddScoped<IQuestionTypeRepository, EFQuestionTypeRepository>();
            services.AddScoped<IQuestionOptionService, QuestionOptionService>();
            services.AddScoped<IQuestionOptionRepository, EFQuestionOptionRepository>();
            services.AddScoped<ICacheService, RedisCacheService>();

            services.AddDbContext<SurveyDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
