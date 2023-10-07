using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class AdministrationsService : EntityBaseRepository<Administration>, IAdministrationsService
	{
		private readonly AppDbContext _context;
        public AdministrationsService(AppDbContext context) : base(context)
        {
        }
    }
}
