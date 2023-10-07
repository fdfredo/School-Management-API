using School_Management_API.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace School_Management_API.Models
{
	public class Administration : IEntityBase
	{
		[Key]
		public int Id { get; set; }
        public string Name { get; set; }
		public string ProfilePicture { get; set; }
		public string Bio { get; set; }
		public string Description { get; set; }
	}
}
