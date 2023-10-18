using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_API.Data.DTOs.StaffDTOs;
using School_Management_API.Data.Services;
using School_Management_API.Models;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffsController : ControllerBase
	{
		private readonly IStaffsService _service;
        public StaffsController(IStaffsService service)
        {
			_service = service;
        }


		//Get: Api/Student
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
		{
			var staff = await _service.GetAllAsync();
			var staffDto = from s in staff
							select new StaffDto
							{
								Name = s.Name,
								PhoneNumber = s.PhoneNumber,
								Email = s.Email,
								Sex = s.Sex
							};
			return Ok(staffDto);
		}

		//Get: Api/Staff/1
		[HttpGet("(id)")]
		public async Task<ActionResult<Staff>> GetStaffById(int id)
		{
			var staff = await _service.GetByIdAsync(id);
			if (staff == null)
			{
				return NotFound();
			}
			return staff;
		}

		//Post: Api/staff
		[HttpPost]
		public async Task<ActionResult<Staff>> Create (Staff createStaffDto)
		{
			var staff = new Staff
			{
				Name = createStaffDto.Name,
				DateJoined = createStaffDto.DateJoined,
				DateOfbirth = createStaffDto.DateOfbirth,
				Address = createStaffDto.Address,
				PhoneNumber = createStaffDto.PhoneNumber,
				Email = createStaffDto.Email,
				Sex = createStaffDto.Sex
			};
			if (!ModelState.IsValid) return staff;
			await _service.AddAsync(staff);
			return CreatedAtAction(nameof(GetStaff), new { id = staff.Id }, staff);
		}

		//Post: Api/staff/1
		[HttpPut("(id)")]
		public async Task<IActionResult> Update (int id, Staff staff)
		{
			if (id != staff.Id)
			{
				return NotFound();
			}
			else
			{
				if (!ModelState.IsValid)
				{
					return Ok(staff);
				}
			}
			await _service.UpdateAsync(id, staff);
			return Ok();
		}


		//Post: Api/staff/1
		[HttpDelete("(id)")]
		public async Task<IActionResult> Delete (int id)
		{
			var staffData = await _service.GetByIdAsync(id);
			if (staffData == null)
			{
				return NotFound();
			}
			await _service.DeleteAsync(id);
			return Ok();
		}
	}
}
