using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class AnswerDisplayResponse : IDto
    {
        public int Id { get; set; }
        [Required]
        public string AnswerText { get; set; }
        public SurveyResponseDisplayResponse Response { get; set; }
        public QuestionDisplayResponse Question { get; set; }
        public IEnumerable<AnswerOptionDisplayResponse> AnswerOptions { get; set; }
    }
}
