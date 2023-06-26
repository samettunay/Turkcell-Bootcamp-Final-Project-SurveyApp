using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("{id}")]
        public IActionResult GetSurvey(int id)
        {
            var survey = _surveyService.GetById(id);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SurveyRequest surveyRequest)
        {
            if (ModelState.IsValid)
            {
                var lastSurveyId = await _surveyService.CreateAndReturnIdAsync(surveyRequest);
                return CreatedAtAction(nameof(GetSurvey), routeValues: new { id = lastSurveyId }, null);
            }
            return BadRequest(ModelState);
        }
    }
}
