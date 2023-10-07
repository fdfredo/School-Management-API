using School_Management_API.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace School_Management_API.Models
{
	public class Result :IEntityBase
	{
		[Key]
		public int Id { get; set; }
        public int StudentId { get; set; }
		public Student Students { get; set; }

		public int CourseId { get; set; }
		public Course Course { get; set; }

		[Required]
		public int Mark { get; set; }
	}
}
