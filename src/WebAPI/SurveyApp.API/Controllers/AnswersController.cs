using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : BaseController<AnswerRequest, AnswerDisplayResponse>
    {
        private readonly IAnswerService _answerService;
        public AnswersController(IAnswerService answerService) : base(answerService)
        {
            _answerService = answerService;
        }
    }
}
