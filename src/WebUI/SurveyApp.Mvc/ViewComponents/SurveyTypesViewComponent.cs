using Microsoft.AspNetCore.Mvc;
using SurveyApp.Services.Services;

namespace SurveyApp.Mvc.ViewComponents
{
    public class SurveyTypesViewComponent : ViewComponent
    {
        private readonly ISurveyTypeService _surveyTypeService;

        public SurveyTypesViewComponent(ISurveyTypeService surveyTypeService)
        {
            _surveyTypeService = surveyTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var surveyTypes = await _surveyTypeService.GetAllAsync();
            return View(surveyTypes);
        }
    }
}
