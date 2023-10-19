using Microsoft.AspNetCore.Mvc;
using SurveyApp.Mvc.Models;
using SurveyApp.Services.Services;

namespace SurveyApp.Mvc.ViewComponents
{
    public class SurveysForMenuViewComponent : ViewComponent
    {
        private readonly ISurveyService _surveyService;
        private readonly ISurveyTypeService _surveyTypeService;

        public SurveysForMenuViewComponent(ISurveyService surveyService, ISurveyTypeService surveyTypeService)
        {
            _surveyService = surveyService;
            _surveyTypeService = surveyTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var surveys = await _surveyService.GetAllAsync();
            var surveyTypes = await _surveyTypeService.GetAllAsync();

            var model = new SurveyComponentModel
            {
                Surveys = surveys,
                SurveyTypes = surveyTypes
            };

            return View(model);
        }
    }
}
