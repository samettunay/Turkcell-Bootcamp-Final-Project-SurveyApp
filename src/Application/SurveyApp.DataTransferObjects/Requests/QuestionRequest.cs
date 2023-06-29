using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class QuestionRequest : IDto
    {
        public int? Id { get; set; }
        public int? Order { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public bool? IsMandatory { get; set; }
        public int QuestionTypeId { get; set; }
        public int SurveyId { get; set; }
    }
}
