namespace SurveyApp.DataTransferObjects.Responses
{
    public class AnswerOptionDisplayResponse : IDto
    {
        public int Id { get; set; }

        public int AnswerId { get; set; }
        public AnswerDisplayResponse Answer { get; set; }

        public int QuestionOptionId { get; set; }
        public QuestionOptionDisplayResponse QuestionOption { get; set; }
    }
}