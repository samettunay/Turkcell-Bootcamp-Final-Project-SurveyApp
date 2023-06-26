﻿using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;

namespace SurveyApp.Services.Services
{
    public interface IAnswerOptionService : IService<AnswerOptionRequest, AnswerOptionDisplayResponse>
    {
    }

}
