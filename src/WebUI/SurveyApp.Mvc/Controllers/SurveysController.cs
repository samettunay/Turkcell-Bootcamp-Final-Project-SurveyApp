using Azure.Core;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Entities;
using SurveyApp.Mvc.Models;
using SurveyApp.Services.Services;
using System.Diagnostics;

namespace SurveyApp.Mvc.Controllers
{
    public class SurveysController : Controller
    {
        private readonly ILogger<SurveysController> _logger;
        private readonly ISurveyService _surveyService;
        private readonly IResponseService _responseService;
        private readonly IAnswerService _answerService;
        private readonly IAnswerOptionService _answerOptionService;
        private readonly ISurveyStatusService _surveyStatusService;
        public SurveysController(ILogger<SurveysController> logger, ISurveyService surveyService, IAnswerService answerService, IAnswerOptionService answerOptionService, IResponseService responseService, ISurveyStatusService surveyStatusService)
        {
            _logger = logger;
            _surveyService = surveyService;
            _answerService = answerService;
            _answerOptionService = answerOptionService;
            _responseService = responseService;
            _surveyStatusService = surveyStatusService;
        }

        public async Task<IActionResult> Index()
        {
            var surveys = await _surveyService.GetAllAsync();

            return View(surveys);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SurveyStatus = await getSurveyStatusForSelectListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SurveyRequest request)
        {
            if (ModelState.IsValid)
            {
                await _surveyService.CreateAsync(request);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SurveyStatus = _surveyStatusService.GetAllAsync();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.SurveyStatus = await getSurveyStatusForSelectListAsync();
            ViewBag.Surveys = await getSurveysForSelectListAsync();

            var survey = await _surveyService.GetByIdAsync(id);

            return View(survey);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SurveyRequest request)
        {
            if (await _surveyService.SurveyIsExists(id))
            {
                if (ModelState.IsValid)
                {
                    await _surveyService.UpdateAsync(request);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.SurveyStatus = getSurveyStatusForSelectListAsync();
                return View();
            }
            return NotFound();
        }

        public async Task<IActionResult> Delete()
        {
            ViewBag.Surveys = await getSurveysForSelectListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _surveyService.SurveyIsExists(id))
            {
                if (ModelState.IsValid)
                {
                    await _surveyService.DeleteAsync(id);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            return NotFound();
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

            return Redirect(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>> getSurveysForSelectListAsync()
        {
            var surveyList = await _surveyService.GetAllAsync();
            var selectListItems = surveyList.Select(survey => new SelectListItem
            {
                Value = survey.Id.ToString(),
                Text = survey.Name
            });
            return selectListItems;
        }

        private async Task<IEnumerable<SelectListItem>> getSurveyStatusForSelectListAsync()
        {
            var surveyStatusList = await _surveyStatusService.GetAllAsync();
            var selectListItems = surveyStatusList.Select(status => new SelectListItem
            {
                Value = status.Id.ToString(),
                Text = status.Status
            });
            return selectListItems;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}