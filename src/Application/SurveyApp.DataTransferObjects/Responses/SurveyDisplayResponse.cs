﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class SurveyDisplayResponse : IResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MinResponses { get; set; }
        public int? MaxResponses { get; set; }

        public SurveyStatusDisplayResponse SurveyStatus { get; set; }
        public IEnumerable<QuestionDisplayResponse> Questions { get; set; }
    }
}
