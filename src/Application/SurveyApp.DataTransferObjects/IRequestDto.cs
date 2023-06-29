namespace SurveyApp.DataTransferObjects
{
    public interface IRequestDto : IDto
    {
        public int? Id { get; set; }
    }
}
