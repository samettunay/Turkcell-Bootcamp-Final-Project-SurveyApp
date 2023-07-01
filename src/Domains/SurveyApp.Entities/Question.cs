using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Entities
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public int? Order { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public bool? IsMandatory { get; set; }

        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
