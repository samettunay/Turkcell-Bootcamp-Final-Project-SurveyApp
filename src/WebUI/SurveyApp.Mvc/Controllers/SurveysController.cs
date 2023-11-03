using AspNetCoreHero.ToastNotification.Abstractions;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Mvc.CacheTools;
using SurveyApp.Mvc.Models;
using SurveyApp.Services.Services;
using System.Diagnostics;

namespace SurveyApp.Mvc.Controllers
{
    public class SurveysController : Controller
    {
        private readonly ILogger<SurveysController> _logger;
        private readonly ISurveyService _surveyService;
        private readonly ISurveyTypeService _surveyTypeService;
        private readonly IResponseService _responseService;
        private readonly IAnswerService _answerService;
        private readonly IAnswerOptionService _answerOptionService;
        private readonly ISurveyStatusService _surveyStatusService;
        private readonly IMemoryCache _memoryCache;
        private readonly INotyfService _notyf;
        public SurveysController(ILogger<SurveysController> logger, ISurveyService surveyService, IAnswerService answerService, IAnswerOptionService answerOptionService, IResponseService responseService, ISurveyStatusService surveyStatusService, ISurveyTypeService surveyTypeService, IMemoryCache memoryCache, INotyfService notyf)
        {
            _logger = logger;
            _surveyService = surveyService;
            _answerService = answerService;
            _answerOptionService = answerOptionService;
            _responseService = responseService;
            _surveyStatusService = surveyStatusService;
            _surveyTypeService = surveyTypeService;
            _memoryCache = memoryCache;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Display(int surveyId)
        {
            var survey = await getSurveyMemCacheOrDb(surveyId);
            return View(survey);
        }

        private async Task<SurveyDisplayResponse> getSurveyMemCacheOrDb(int surveyId)
        {
            if (!_memoryCache.TryGetValue("Survey", out CacheDataInfo cacheDataInfo))
            {
                var options = new MemoryCacheEntryOptions()
                                  .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                  .SetPriority(CacheItemPriority.Normal);

                cacheDataInfo = new CacheDataInfo
                {
                    CacheTime = DateTime.Now,
                    Survey = await _surveyService.GetByIdAsync(surveyId)
                };

                _memoryCache.Set("Survey", cacheDataInfo, options);
            }

             return cacheDataInfo.Survey;  
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

            try
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
                var successMessage = "Sending successful!";
                _notyf.Success(successMessage);
            }
            catch (Exception)
            {
                var errorMessage = "An error occurred, please try again.";
                _notyf.Error(errorMessage);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetSurveysByTypeId(int surveyTypeId)
        {
            var surveys = await _surveyService.GetSurveysByTypeIdAsync(surveyTypeId);
            return ViewComponent("SurveyList", surveys);
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