using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyTypeController : BaseController<SurveyTypeRequest, SurveyTypeDisplayResponse>
    {
        private readonly ISurveyTypeService _surveyTypeService;
        public SurveyTypeController(ISurveyTypeService surveyTypeService) : base(surveyTypeService)
        {
            _surveyTypeService = surveyTypeService;
        }
    }
}
