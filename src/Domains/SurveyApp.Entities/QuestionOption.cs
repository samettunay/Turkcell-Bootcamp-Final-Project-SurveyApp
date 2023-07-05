using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Entities
{
    public class QuestionOption : IEntity
    {
        public int Id { get; set; }
        public int? Order { get; set; }
        [Required]
        public string Value { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswerOption>? AnswerOptions { get; set; }
    }
}
