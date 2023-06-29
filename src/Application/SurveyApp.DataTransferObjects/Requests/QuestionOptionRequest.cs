using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class QuestionOptionRequest : IRequestDto
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public int Order { get; set; }
        [Required]
        public string Value { get; set; }

        public int QuestionId { get; set; }
    }
}
