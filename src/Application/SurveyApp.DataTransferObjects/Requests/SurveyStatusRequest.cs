using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class SurveyStatusRequest : IRequestDto
    {
        [JsonIgnore]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakmayınız!")]
        public string Status { get; set; }
    }
}
