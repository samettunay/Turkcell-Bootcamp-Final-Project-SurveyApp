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
            return View();
        }

        public async Task<IActionResult> Display(int surveyId)
        {
            var responses = await _responseService.GetAllAsync();
            var surveyResponses = responses.Where(r => r.Survey.Id == surveyId);
            var result = surveyResponses.SelectMany(r => r.Answers).ToList();
            return View(result);
        }
    }
}
