using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class SurveyResponseDisplayResponse : IDto
    {
        public int? Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public RespondentDisplayResponse Respondent { get; set; }

        public SurveyDisplayResponse Survey { get; set; }

        public IEnumerable<AnswerDisplayResponse> Answers { get; set; }
    }
}
