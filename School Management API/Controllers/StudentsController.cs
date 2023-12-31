﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using School_Management_API.Data.DTOs;
using School_Management_API.Data.DTOs.StudentDTOs;
using School_Management_API.Data.Services;
using School_Management_API.Models;
using System.Collections;

namespace School_Management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentsService _service;
        public StudentsController(IStudentsService service)
        {
			_service = service;
        }

		//Get: Api/Student
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
		{
			var students = await _service.GetAllAsync();
			var studentsDto = from s in students
							  select new StudentDto()
							  {
								  Id = s.Id,
								  Name = s.Name,
								  Phonenumber = s.PhoneNumber,
								  Email = s.Email,
								  Sex = s.Sex
							  };
			return Ok(studentsDto); 
		}

		//Get: Api/Student/1
		[HttpGet("(id)")]
		public async Task<ActionResult<Student>> GetStudentById(int id)
		{
			var student = await _service.GetByIdAsync(id);
			if(student == null)
			{
				return NotFound();
			}
			return student;
		}

		//Post: Api/student
		[HttpPost]
		public async Task<ActionResult<Student>> Create (Student CreateStudentDto)
		{
			var student = new Student
			{
				Name = CreateStudentDto.Name,
				ParentName = CreateStudentDto.ParentName,
				DateOfbirth = CreateStudentDto.DateOfbirth,
				Address = CreateStudentDto.Address,
				PhoneNumber = CreateStudentDto.PhoneNumber,
				Email = CreateStudentDto.Email,
				Password = CreateStudentDto.Password,
				Sex = CreateStudentDto.Sex
			};

			if (!ModelState.IsValid) return student;
			await _service.AddAsync(student);
			return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
		}

		//Post: Api/student/1
		[HttpPut("(id)")]
		public async Task<IActionResult> Update (int id, Student student)
		{
			if (id != student.Id)
			{
				return NotFound();
			}
			else
			{
				if (!ModelState.IsValid)
				{
					return Ok(student);
				}
			}
			await _service.UpdateAsync(id, student);
			return Ok();
		}

		//Delete: Api/student/1
		[HttpDelete("(id)")]
		public async Task<IActionResult> Delete (int id)
		{
			var studentData = await _service.GetByIdAsync(id);
			if(studentData == null)
			{
				return NotFound();
			}
			await _service.DeleteAsync(id);
			return Ok();
		}
	}
}
