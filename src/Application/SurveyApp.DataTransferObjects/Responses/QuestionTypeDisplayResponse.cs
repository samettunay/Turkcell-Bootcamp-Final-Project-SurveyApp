namespace SurveyApp.DataTransferObjects.Responses
{
    public class QuestionTypeDisplayResponse : IResponseDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}