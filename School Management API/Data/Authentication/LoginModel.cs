using System.ComponentModel.DataAnnotations;

namespace School_Management_API.Data.Authentication
{
	public class LoginModel
	{
        [Required(ErrorMessage ="This field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string Password { get; set; }
    }
}
