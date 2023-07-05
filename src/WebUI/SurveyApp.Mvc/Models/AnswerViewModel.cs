namespace SurveyApp.Mvc.Models
{
    public class AnswerViewModel
    {
        public int QuestionId { get; set; }
        public int AnswerOptionId { get; set; }
        public List<int> AnswerOptionIds { get; set; }
        public string AnswerText { get; set; }
    }
}
