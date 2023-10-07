using School_Management_API.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_API.Models
{
	public class Course : IEntityBase
	{
		[Key]
		public int Id { get; set; }

		[Required]
        public string Name { get; set; }
		public int Score { get; set; }
		public string Grade { get; set; }
		public string Description { get; set; }


		//Relationships

		//Students
		public int StudentId { get; set; }
		[ForeignKey("StudentId")]
		public Student Students { get; set; }

		//Staff
		public int StaffId { get; set; }
		[ForeignKey("StaffId")]
		public Staff Staff { get; set; }


	}
}
