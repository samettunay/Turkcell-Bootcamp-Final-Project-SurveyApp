namespace SurveyApp.DataTransferObjects.Responses
{
    public class AnswerOptionDisplayResponse : IResponseDto
    {
        public int Id { get; set; }
        public AnswerDisplayResponse Answer { get; set; }
        public QuestionOptionDisplayResponse QuestionOption { get; set; }
    }
}