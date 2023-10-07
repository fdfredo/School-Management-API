using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_API.Data.Services;
using School_Management_API.Models;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FacultiesController : ControllerBase
	{
		private readonly IFacultiesService _service;
        public FacultiesController(IFacultiesService service)
        {
			_service = service;
        }


		//Get: api/faculty
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Faculty>>> Get()
		{
			var data = await _service.GetAllAsync();
			return Ok();
		}

		//Post: api/faculty
		[HttpPost]
		public async Task<ActionResult<Faculty>> Create(Faculty faculty)
		{
			await _service.AddAsync(faculty);
			return CreatedAtAction("Get", new { id = faculty.Id }, faculty);
		}

		//Delete: api/faculty/1
		[HttpDelete("(id)")]
		public async Task<IActionResult> Delete (int id)
		{
			var data = await _service.GetByIdAsync(id);
			if (data == null) return NotFound();
			await _service.DeleteAsync(id);
			return Ok();
		}
	}
}
