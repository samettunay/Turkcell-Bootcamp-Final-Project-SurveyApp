using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class QuestionDisplayResponse : IDto
    {
        public int Id { get; set; }
        public int? Order { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public bool? IsMandatory { get; set; }

        public QuestionTypeDisplayResponse QuestionType { get; set; }
        public ICollection<SurveyDisplayResponse> Surveys { get; set; }
        public ICollection<QuestionOptionDisplayResponse> QuestionOptions { get; set; }
    }
}