using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_API.Data.Services;
using School_Management_API.Models;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdministrationsController : ControllerBase
	{
		private readonly IAdministrationsService _service;
        public AdministrationsController(IAdministrationsService service)
        {
			_service = service;
        }

		//Get:api/administration
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Administration>>> GetAdmin()
		{
			var admin = await _service.GetAllAsync();
			return Ok();
		}

		//Post:api/administration/
		[HttpPost]
		public async Task<ActionResult<Administration>> Create(Administration administrators)
		{
			if (!ModelState.IsValid)
			{
				return Ok(administrators);
			}
			await _service.AddAsync(administrators);
			return CreatedAtAction("GetAdmin", new { id = administrators.Id }, administrators);
		}

		//Put:api/administrator/1
		[HttpPut("(id)")]
		public async Task<IActionResult> Update(int id, Administration administrators)
		{
			var admin = await _service.GetByIdAsync(id);
			if (admin == null)
			{
				return NotFound();
			}
			else
			{
				if (!ModelState.IsValid)
				{
					return Ok(administrators);
				}
			}
			await _service.UpdateAsync(id, administrators);
			return Ok();
		}

		//Delete: api/administration/1
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
