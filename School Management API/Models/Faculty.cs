using School_Management_API.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace School_Management_API.Models
{
	public class Faculty:IEntityBase
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
