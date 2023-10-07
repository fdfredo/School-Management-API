using School_Management_API.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_API.Models
{
	public class TimeTable : IEntityBase
	{
		[Key]
		public int Id { get; set; }

		[Required]
        public DateTime Day { get; set; }

		[Required]
		public DateTime StartTime { get; set; }
		
		[Required]
		public DateTime EndTime { get; set; }

		[Required]
		public string Course { get; set; }

		//Relationship
		public int StaffId { get; set; }
		[ForeignKey("StaffId")]
		public Staff Staff { get; set; }

	}
}
