using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionOptionsController : BaseController<QuestionOptionRequest, QuestionOptionDisplayResponse>
    {
        private readonly IQuestionOptionService _questionOptionService;
        public QuestionOptionsController(IQuestionOptionService questionOptionService) : base(questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }
    }
}
