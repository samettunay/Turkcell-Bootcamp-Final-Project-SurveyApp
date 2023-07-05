using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Entities;
using SurveyApp.Mvc.Models;
using SurveyApp.Services.Services;
using System.Diagnostics;

namespace SurveyApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISurveyService _surveyService;
        private readonly IResponseService _responseService;
        private readonly IAnswerService _answerService;
        private readonly IAnswerOptionService _answerOptionService;
        public HomeController(ILogger<HomeController> logger, ISurveyService surveyService, IAnswerService answerService, IAnswerOptionService answerOptionService, IResponseService responseService)
        {
            _logger = logger;
            _surveyService = surveyService;
            _answerService = answerService;
            _answerOptionService = answerOptionService;
            _responseService = responseService;
        }

        public async Task<IActionResult> Index()
        {
            var surveys = await _surveyService.GetAllAsync();

            return View(surveys);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAnswers(ResponseViewModel response)
        {

            var responseRequest = new SurveyResponseRequest
            {
                RespondentId = 1,
                SurveyId = response.SurveyId,
            };

            var responseId = await _responseService.CreateAndReturnIdAsync(responseRequest);

            foreach (var answer in response.Answers)
            {
                var answerRequest = new AnswerRequest
                {
                    AnswerText = answer.AnswerText,
                    QuestionId = answer.QuestionId,
                    ResponseId = responseId,
                };

                var answerId = await _answerService.CreateAndReturnIdAsync(answerRequest);
                
                if (answer.AnswerOptionIds != null)
                {
                    foreach (var answerOptionId in answer.AnswerOptionIds)
                    {
                        var answerOptionRequest = new AnswerOptionRequest
                        {
                            AnswerId = answerId,
                            QuestionOptionId = answerOptionId,
                        };
                        await _answerOptionService.CreateAsync(answerOptionRequest);
                    }
                }

                if (answer.AnswerOptionId != null)
                {
                    var answerOptionRequest = new AnswerOptionRequest
                    {
                        AnswerId = answerId,
                        QuestionOptionId = answer.AnswerOptionId,
                    };
                    await _answerOptionService.CreateAsync(answerOptionRequest);
                }

            }

            return Json(response);
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