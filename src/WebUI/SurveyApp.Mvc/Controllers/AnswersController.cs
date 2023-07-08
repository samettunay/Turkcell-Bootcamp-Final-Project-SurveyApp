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
            var answerOptions = await _answerOptionService.GetAllAsync();
            var questions = await _questionService.GetAllAsync();

            var chartModel = new ChartViewModel
            {
                AnswerOptions = answerOptions,
                Questions = questions
            };

            return View(chartModel);
        }
    }
}
