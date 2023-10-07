using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_API.Data.Services;
using School_Management_API.Models;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResultsController : ControllerBase
	{
		private readonly IResultsService _service;
		public ResultsController(IResultsService service)
		{
			_service = service;
		}

		//Get: api/result
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Result>>> Get()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		//Get: api/result/1
		[HttpGet("(id)")]
		public async Task<ActionResult<Result>> GetId(int id)
		{
			var data = await _service.GetByIdAsync(id);
			if (data == null) return NotFound();
			return Ok(data);
		}

		//Post: api/result/1
		[HttpPost]
		public async Task<ActionResult> Create(Result result)
		{
			if (!ModelState.IsValid)
			{
				return Ok(result);
			}
			await _service.AddAsync(result);
			return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
		}

		//Put: api/result/1
		[HttpPut("(id)")]
		public async Task<IActionResult> Update(int id, Result result)
		{
			var data = await _service.GetByIdAsync(id);
			if (data == null)
			{
				return NotFound();
			}
			else
			{
				if (!ModelState.IsValid)
				{
					return Ok();
				}
			}
			await _service.UpdateAsync(id, result);
			return Ok();
		}

		//Delete: api/result/1
		[HttpDelete("(id)")]
		public async Task<IActionResult> Delete(int id)
		{
			var details = await _service.GetByIdAsync(id);
			if (details == null) return NotFound();
			await _service.DeleteAsync(id);
			return Ok();
		}
	}
}
