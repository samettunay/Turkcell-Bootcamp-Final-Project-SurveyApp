using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.API.Filters;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : BaseController<SurveyRequest, SurveyDisplayResponse>
    {
        private readonly ISurveyService _surveyService;
        public SurveysController(ISurveyService surveyService) : base(surveyService)
        {
            _surveyService = surveyService;
        }
    }
}
