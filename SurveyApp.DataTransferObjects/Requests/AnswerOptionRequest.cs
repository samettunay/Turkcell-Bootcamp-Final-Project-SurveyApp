using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class AnswerOptionRequest : IDto
    {
        public int? Id { get; set; }
        public int AnswerId { get; set; }
        public int QuestionOptionId { get; set; }
    }
}
