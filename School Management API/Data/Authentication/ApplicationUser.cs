using Microsoft.AspNetCore.Identity;

namespace School_Management_API.Data.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
