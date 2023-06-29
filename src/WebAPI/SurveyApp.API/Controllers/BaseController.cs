using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.API.Filters;
using SurveyApp.DataTransferObjects;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Entities;
using SurveyApp.Services.Services;

namespace SurveyApp.API.Controllers
{
    public abstract class BaseController<TRequest, TResponse> : ControllerBase
                                where TRequest : class, IRequestDto, new()
                                where TResponse : class, IResponseDto, new()
    {
        private readonly IService<TRequest, TResponse> _service;

        public BaseController(IService<TRequest, TResponse> service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public virtual IActionResult GetAll()
        {
            var items = _service.GetAll();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("[action]")]
        public virtual IActionResult GetById(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Create(TRequest request)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("[action]/{id}")]
        [IsExists]
        public virtual async Task<IActionResult> Update(int id, TRequest request)
        {
            if (ModelState.IsValid)
            {
                request.Id = id;
                await _service.UpdateAsync(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("[action]/{id}")]
        [IsExists]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
