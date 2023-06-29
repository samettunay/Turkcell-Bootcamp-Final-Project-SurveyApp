using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class SurveyStatusDisplayResponse : IResponseDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<SurveyDisplayResponse> Surveys { get; set; }
    }
}
