using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Responses;

namespace SurveyApp.Mvc.ViewComponents
{
    public class FilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<SurveyTypeDisplayResponse> model)
        {
            return View(model);
        }
    }
}
