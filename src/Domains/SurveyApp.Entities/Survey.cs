using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class Survey : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MinResponses { get; set; }
        public int? MaxResponses { get; set; }

        public int SurveyStatusId { get; set; }
        public int SurveyTypeId { get; set; }
        public SurveyStatus SurveyStatus { get; set; }
        public SurveyType SurveyType { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
