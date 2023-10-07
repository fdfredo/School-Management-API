using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_API.Data.Services;
using School_Management_API.Models;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdmissionsController : ControllerBase
	{
		private readonly IAdmissionsService _service;
        public AdmissionsController(IAdmissionsService service)
        {
			_service = service;
        }

		//Get: api/admissions
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Admission>>> Get()
		{
			var data = await _service.GetAllAsync();
			return Ok(data);
		}

		//Post: api/admissions
		[HttpPost]
		public async Task<ActionResult<Admission>> Create (Admission admission)
		{
			await _service.AddAsync(admission);
			return CreatedAtAction("Get", new {id = admission.Id}, admission);
		}

		//Delete: api/asdmission:1
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
