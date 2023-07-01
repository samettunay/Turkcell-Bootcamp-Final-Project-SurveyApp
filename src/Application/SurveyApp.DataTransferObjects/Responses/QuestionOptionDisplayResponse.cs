using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class QuestionOptionDisplayResponse : IResponseDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        [Required]
        public string Value { get; set; }
    }
}