using System.ComponentModel.DataAnnotations;

namespace School_Management_API.Data.DTOs.StudentDTOs
{
    public class CreateStudentDto
    {

		[Required]
		public string Name { get; set; }

		[Required]
		public string ParentName { get; set; }

		[Required]
		public DateTime DateOfbirth { get; set; }

		[Required]
		public double Address { get; set; }

		[Required(ErrorMessage = "Phone number?")]
		public int PhoneNumber { get; set; }

		[Required(ErrorMessage = "Enter Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Enter Password")]
		[StringLength(40, MinimumLength = 8, ErrorMessage = "Must not be less than 8 characters")]
		public string Password { get; set; }

		[Required]
		public string Sex { get; set; }
	}
}
