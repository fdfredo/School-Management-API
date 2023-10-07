using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_API.Data.Services;
using School_Management_API.Models;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurriculumsController : ControllerBase
	{
		private readonly ICurriculumsService _service;
        public CurriculumsController(ICurriculumsService service)
        {
			_service = service;
        }

		//Get: api/Curriculum
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Curriculum>>> Get()
		{
			var data = await _service.GetAllAsync();
			return Ok(data);
		}

		//Post: api/Curriculum
		[HttpPost]
		public async Task<ActionResult<IEnumerable<Curriculum>>> Create (Curriculum curriculum)
		{
			await _service.AddAsync(curriculum);
			return CreatedAtAction("Get", new { id = curriculum.Id }, curriculum);
		}

		//Delete: apa/curriculum/1
		[HttpDelete("(id)")]
		public async Task<IActionResult> Delete(int id)
		{
			var data = await _service.GetByIdAsync(id);
			if (data == null) return NotFound();
			await _service.DeleteAsync(id);
			return Ok();
		}
	}
}
