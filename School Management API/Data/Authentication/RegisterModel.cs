using System.ComponentModel.DataAnnotations;

namespace School_Management_API.Data.Authentication
{
	public class RegisterModel
	{
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="This field is requred")]
        public string Password { get; set; }
    }
}
