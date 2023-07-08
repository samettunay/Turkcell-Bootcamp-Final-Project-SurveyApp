using SurveyApp.DataTransferObjects.Responses;

namespace SurveyApp.Mvc.Models
{
    public class ChartViewModel
    {
        public IEnumerable<AnswerOptionDisplayResponse> AnswerOptions { get; set; }
        public IEnumerable<QuestionDisplayResponse> Questions { get; set; }

    }
}
