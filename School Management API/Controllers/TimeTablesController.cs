using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_API.Data.Services;
using School_Management_API.Models;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TimeTablesController : ControllerBase
	{
		private readonly ITimeTablesService _service;
        public TimeTablesController(ITimeTablesService service)
        {
			_service = service;
        }

		//Get: api/timetable
		[HttpGet]
		public async Task <ActionResult<IEnumerable<TimeTable>>> GetStudentTimeTable()
		{
			var data = await _service.GetAllAsync();
			return Ok(data);
		}

		//Get: api/timetable/1
		[HttpGet("(id)")]
		public async Task<ActionResult<IEnumerable<TimeTable>>> GetCourseTimeById(int id)
		{
			var result = await _service.GetByIdAsync(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

		//Post: api/timetable
		[HttpPost]
		public async Task<ActionResult> Create(TimeTable timeTable)
		{
			if (!ModelState.IsValid)
			{
				return Ok(timeTable);
			}
			else
			{
				await _service.AddAsync(timeTable);
			}
			return CreatedAtAction("GetStudentTimeTable", new { id = timeTable.Id }, timeTable);
		}

		//Put: api/timetable/id
		[HttpPut("(id)")]
		public async Task<IActionResult> Update(int id, TimeTable timeTable)
		{
			var course = await _service.GetByIdAsync(id);
			if(course == null)
			{
				return NotFound();
			}
			else
			{
				if (!ModelState.IsValid)
				{
					return Ok(course);
				}
			}
			await _service.UpdateAsync(id, timeTable);
			return Ok();
		}

		//Delete:api/timetable
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var data = await _service.GetByIdAsync(id);
			if (data == null) return NotFound();
			await _service.DeleteAsync(id);
			return Ok();
		}




    }
}
