using SurveyApp.DataTransferObjects.Responses;

namespace SurveyApp.Mvc.Models
{
    public class SurveyComponentModel
    {
        public IEnumerable<SurveyDisplayResponse> Surveys { get; set; }
        public IEnumerable<SurveyTypeDisplayResponse> SurveyTypes { get; set; }
    }
}
