using SurveyApp.DataTransferObjects.Responses;

namespace SurveyApp.Mvc.CacheTools
{
    public class CacheDataInfo
    {
        public SurveyDisplayResponse Survey { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
