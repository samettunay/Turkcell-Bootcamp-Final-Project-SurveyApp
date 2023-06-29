using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SurveyApp.API.Filters
{
    public class NotImplementedAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                string message = $"Request gönderdiğiniz adreste herhangi bir geliştirme yapılmamıştır action adı:{context.ActionDescriptor.DisplayName}";
                context.Result = new BadRequestObjectResult(new { errorMessage = message });
            }
        }
    }
    
}
