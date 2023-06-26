using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Entities
{
    public class Answer : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string AnswerText { get; set; }

        public int ResponseId { get; set; }
        public Response Response { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public ICollection<AnswerOption> AnswerOptions { get; set; }
    }
}
