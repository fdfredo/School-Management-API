using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class ExamsService : EntityBaseRepository<Exam>, IExamsService
	{
		private readonly AppDbContext _context;
        public ExamsService(AppDbContext context) : base(context)
        {
        }
    }
}
