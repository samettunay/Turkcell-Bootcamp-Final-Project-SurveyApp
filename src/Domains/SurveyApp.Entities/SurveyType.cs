using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class SurveyType : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }
}
