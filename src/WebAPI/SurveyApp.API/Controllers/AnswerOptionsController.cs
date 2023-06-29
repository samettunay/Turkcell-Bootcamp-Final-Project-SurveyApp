using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerOptionsController : BaseController<AnswerOptionRequest, AnswerOptionDisplayResponse>
    {
        private readonly IAnswerOptionService _answerOptionService;
        public AnswerOptionsController(IAnswerOptionService answerOptionService) : base(answerOptionService)
        {
            _answerOptionService = answerOptionService;
        }
    }
}
