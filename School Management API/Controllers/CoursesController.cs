using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_API.Data.Services;
using School_Management_API.Models;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private readonly ICoursesService _service;
        public CoursesController(ICoursesService service)
        {
			_service = service;
        }

		//Get: api/courses
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		//Post: api/course
		[HttpPost]
		public async Task<ActionResult<Course>> Create (Course course)
		{
			if (!ModelState.IsValid)
			{
				return Ok(course);
			}
			await _service.AddAsync(course);
			return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
		}

		//Put: api/course/1
		[HttpPut("(id)")]
		public async Task<IActionResult> Update(int id, Course course)
		{
			var details = await _service.GetByIdAsync(id);
			if (details == null)
			{
				return NotFound();
			}
			else
			{
				if (!ModelState.IsValid)
				{
					return Ok(details);
				}
			}
			await _service.UpdateAsync(id, course);
			return Ok();
		}

		//Delete: api/course/1
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
