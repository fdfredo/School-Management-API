using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class StaffsService : EntityBaseRepository<Staff>, IStaffsService
	{
		private readonly AppDbContext _context;
        public StaffsService(AppDbContext context) : base(context)
        {
        }
    }
}
