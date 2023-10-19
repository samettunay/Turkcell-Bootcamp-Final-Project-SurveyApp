using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class SurveyRequest : IRequestDto
    {
        [JsonIgnore]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakmayınız!")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MinResponses { get; set; }
        public int? MaxResponses { get; set; }
        public int SurveyStatusId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
