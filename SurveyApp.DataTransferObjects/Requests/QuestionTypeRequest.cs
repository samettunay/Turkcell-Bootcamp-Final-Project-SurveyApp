﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class QuestionTypeRequest : IDto
    {
        public int? Id { get; set; }
        public string Type { get; set; }
    }
}
