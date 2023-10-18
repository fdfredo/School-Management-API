namespace School_Management_API.Data.DTOs.StaffDTOs
{
	public class CreateStaffDto
	{
		public string Name { get; set; }
		public DateTime DateJoined { get; set; }
		public DateTime DateOfbirth { get; set; }
		public double Address { get; set; }
		public int PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Sex { get; set; }
	}
}
