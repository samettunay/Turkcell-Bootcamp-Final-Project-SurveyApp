using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Responses;

namespace SurveyApp.Mvc.ViewComponents
{
    public class SurveyListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<SurveyDisplayResponse> model)
        {
            return View(model);
        }
    }
}
