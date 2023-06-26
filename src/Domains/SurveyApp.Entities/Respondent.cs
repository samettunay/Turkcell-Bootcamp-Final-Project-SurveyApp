namespace SurveyApp.Entities
{
    public class Respondent : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<Response> Responses { get; set; }
    }
}
