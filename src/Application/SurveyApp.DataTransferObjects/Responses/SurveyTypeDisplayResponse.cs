namespace SurveyApp.DataTransferObjects.Responses
{
    public class SurveyTypeDisplayResponse : IResponseDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public IEnumerable<SurveyDisplayResponse> Surveys { get; set; }
    }
}
