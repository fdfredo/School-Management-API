using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_API.Data.Services;
using School_Management_API.Models;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExamsController : ControllerBase
	{
		private readonly IExamsService _service;
        public ExamsController(IExamsService service)
        {
			_service = service;
        }

		//Get: api/exams
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
		{
			var data = await _service.GetAllAsync();
			return Ok(data);
		}

		//Get: api/exams/id
		[HttpGet("(id)")]
		public async Task <ActionResult<Exam>> GetExamId(int id)
		{
			var exam = await _service.GetByIdAsync(id);
			if (exam == null) return NotFound();
			return Ok();
		}

		//Post: api/exams
		[HttpPost]
		public async Task<ActionResult<Exam>> Create(Exam exam)
		{
			if (!ModelState.IsValid)
			{
				return Ok(exam);
			}
			await _service.AddAsync(exam);
			return CreatedAtAction(nameof(GetExams), new { id = exam.Id }, exam);
		}

		//Put:api/exam/1
		[HttpPut("(id)")]
		public async Task<IActionResult> Update (int id, Exam exam)
		{
			if(id != exam.Id)
			{
				return NotFound();
			}
			else
			{
				if (!ModelState.IsValid)
				{
					return Ok(exam);
				}
			}
			await _service.UpdateAsync(id, exam);
			return Ok();
		}

		//Delete: api/exam
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
