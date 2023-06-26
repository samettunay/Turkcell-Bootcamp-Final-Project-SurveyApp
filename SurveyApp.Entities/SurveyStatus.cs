namespace SurveyApp.Entities
{
    public class SurveyStatus : IEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }
}
