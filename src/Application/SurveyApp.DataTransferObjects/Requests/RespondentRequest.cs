using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class RespondentRequest : IRequestDto
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}
