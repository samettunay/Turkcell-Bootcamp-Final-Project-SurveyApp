using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using SurveyApp.Mvc.Models;
using SurveyApp.Services.Services;

namespace SurveyApp.Mvc.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ISurveyService _surveyService;
        private readonly IQuestionTypeService _questionTypeService;
        private readonly IQuestionService _questionService;
        private readonly IQuestionOptionService _questionOptionService;
        private readonly IMemoryCache _memoryCache;
        public QuestionsController(ISurveyService surveyService, IQuestionTypeService questionTypeService, IQuestionService questionService, IQuestionOptionService questionOptionService, IMemoryCache memoryCache)
        {
            _surveyService = surveyService;
            _questionTypeService = questionTypeService;
            _questionService = questionService;
            _questionOptionService = questionOptionService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Surveys = await getSurveysForSelectListAsync();
            ViewBag.QuestionTypeRequest = await getQuestionTypeForSelectListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var questionId = await _questionService.CreateAndReturnIdAsync(request.QuestionRequest);
                request.QuestionOptionRequest.QuestionId = questionId;

                await _questionOptionService.CreateAsync(request.QuestionOptionRequest);
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }

        private async Task<IEnumerable<SelectListItem>> getQuestionTypeForSelectListAsync()
        {
            var surveyList = await _questionTypeService.GetAllAsync();
            var selectListItems = surveyList.Select(questionType => new SelectListItem
            {
                Value = questionType.Id.ToString(),
                Text = questionType.Type
            });
            return selectListItems;
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
    }
}
