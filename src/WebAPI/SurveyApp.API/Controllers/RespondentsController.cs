using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespondentsController : BaseController<RespondentRequest, RespondentDisplayResponse>
    {
        private readonly IRespondentService _respondentService;
        public RespondentsController(IRespondentService respondentService) : base(respondentService)
        {
            _respondentService = respondentService;
        }
    }
}
