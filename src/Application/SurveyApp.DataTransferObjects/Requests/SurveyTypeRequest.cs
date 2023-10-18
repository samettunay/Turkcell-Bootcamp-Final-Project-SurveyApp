using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class SurveyTypeRequest : IRequestDto
    {
        [JsonIgnore]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakmayınız!")]
        public string Type { get; set; }
    }
}
