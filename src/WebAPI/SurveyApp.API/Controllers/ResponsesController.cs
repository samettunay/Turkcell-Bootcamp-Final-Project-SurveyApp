using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsesController : BaseController<SurveyResponseRequest, SurveyResponseDisplayResponse>
    {
        private readonly IResponseService _responseService;
        public ResponsesController(IResponseService responseService) : base(responseService)
        {
            _responseService = responseService;
        }
    }
}
