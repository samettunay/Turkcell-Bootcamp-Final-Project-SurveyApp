using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Mvc.Models;
using SurveyApp.Services.Services;
using System.Diagnostics;

namespace SurveyApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISurveyService _surveyService;

        public HomeController(ILogger<HomeController> logger, ISurveyService surveyService)
        {
            _logger = logger;
            _surveyService = surveyService;
        }

        public async Task<IActionResult> Index()
        {
            var surveys = await _surveyService.GetAllAsync();

            return View(surveys);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SurveyResponseModel model)
            //Respondent Name EmailAddress
        {   //Response RespondentId SurveyId
            //Answer AnswerText ResponseId QuestionId
            //AnswerOption AnswerId QuestionOptionId
            return Json(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}