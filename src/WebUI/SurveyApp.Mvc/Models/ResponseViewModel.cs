namespace SurveyApp.Mvc.Models
{
    public class ResponseViewModel
    {
        public int SurveyId { get; set; }
        public int RespondentId { get; set; }
        public IList<AnswerViewModel> Answers { get; set; }
    }
}
