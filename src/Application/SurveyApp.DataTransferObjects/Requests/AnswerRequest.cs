﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class AnswerRequest : IRequestDto
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? AnswerText { get; set; }
        public int ResponseId { get; set; }
        public int QuestionId { get; set; }
    }
}
