using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class QuestionOptionDisplayResponse : IDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        [Required]
        public string Value { get; set; }

        public int QuestionId { get; set; }
        public QuestionDisplayResponse Question { get; set; }
    }
}