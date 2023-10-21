using Microsoft.AspNetCore.Mvc;
using SurveyApp.Mvc.Models;
using SurveyApp.Services.Services;

namespace SurveyApp.Mvc.Controllers
{
    public class AnswersController : Controller
    {
        private readonly IResponseService _responseService;
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerOptionService _answerOptionService;
        public AnswersController(IResponseService responseService, IAnswerService answerService, IQuestionService questionService, IAnswerOptionService answerOptionService)
        {
            _responseService = responseService;
            _answerService = answerService;
            _questionService = questionService;
            _answerOptionService = answerOptionService;
        }

        public async Task<IActionResult> Index()
        {
            var answers = await _answerService.GetAllAsync();

            return View(answers);
        }
    }
}
