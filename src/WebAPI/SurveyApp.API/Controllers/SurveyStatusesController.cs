using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyStatusesController : BaseController<SurveyStatusRequest, SurveyStatusDisplayResponse>
    {
        private readonly ISurveyStatusService _surveyStatusService;
        public SurveyStatusesController(ISurveyStatusService surveyStatusService) : base(surveyStatusService)
        {
            _surveyStatusService = surveyStatusService;
        }
    }
}
