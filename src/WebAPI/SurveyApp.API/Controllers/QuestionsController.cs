﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : BaseController<QuestionRequest, QuestionDisplayResponse>
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService) : base(questionService)
        {
            _questionService = questionService;
        }
    }
}
