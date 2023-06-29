using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Filters
{
    public class IsExistsFilter : IAsyncActionFilter
    {
        private readonly ISurveyService _surveyService;

        public IsExistsFilter(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idParameterIsExists = context.ActionArguments.ContainsKey("id");

            if (!idParameterIsExists)
            {
                context.Result = new BadRequestObjectResult(new { message = $"{context.ActionDescriptor.DisplayName} actionu, id parametresi içermelidir." });
            }
            else
            {
                var id = (int)context.ActionArguments["id"];
                if (await _surveyService.SurveyIsExists(id))
                {
                    await next.Invoke();
                }
                context.Result = new NotFoundObjectResult(new { message = $"{id} id not found!" });
            }
        }
    }
}
