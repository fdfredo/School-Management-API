using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class TimeTablesService : EntityBaseRepository<TimeTable>, ITimeTablesService
	{
		private readonly AppDbContext _context;
        public TimeTablesService(AppDbContext context) :base(context)
        {
        }
    }
}
