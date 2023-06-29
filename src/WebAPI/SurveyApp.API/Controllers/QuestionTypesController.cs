using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypesController : BaseController<QuestionTypeRequest, QuestionTypeDisplayResponse>
    {
        private readonly IQuestionTypeService _questionTypeService;
        public QuestionTypesController(IQuestionTypeService questionTypeService) : base(questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }
    }
}
