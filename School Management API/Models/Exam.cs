using School_Management_API.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_API.Models
{
	public class Exam : IEntityBase
	{
		[Key]
		public int Id { get; set; }
		
        public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public double Venue { get; set; }

        //Relationships
        public int StudentId { get; set; }
		[ForeignKey("StudentId")]
        public Student Students { get; set; }

    }
}
