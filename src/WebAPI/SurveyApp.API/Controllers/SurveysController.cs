using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.API.Filters;
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

        [HttpGet]
        public IActionResult GetSurveys()
        {
            var surveys = _surveyService.GetAll();
            return Ok(surveys);
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

        [HttpPut("{id}")]
        [IsExists]
        public async Task<IActionResult> Update(int id, SurveyRequest request)
        {
            if (ModelState.IsValid)
            {
                request.Id = id;
                await _surveyService.UpdateAsync(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [IsExists]
        public async Task<IActionResult> Delete(int id)
        {
            await _surveyService.DeleteAsync(id);
            return Ok();
        }
    }
}
