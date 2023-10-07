using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class AdmissionsService : EntityBaseRepository<Admission>, IAdmissionsService
	{
		private readonly AppDbContext _context;
        public AdmissionsService(AppDbContext context) : base(context)
        {
        }
    }
}
