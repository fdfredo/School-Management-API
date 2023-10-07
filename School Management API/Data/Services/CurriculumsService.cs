using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class CurriculumsService : EntityBaseRepository<Curriculum>, ICurriculumsService
	{
		private readonly AppDbContext _context;
        public CurriculumsService(AppDbContext context):base(context)
        {
        }
    }
}
