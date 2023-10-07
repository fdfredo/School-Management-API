using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class CoursesService : EntityBaseRepository<Course>, ICoursesService
	{
		private readonly AppDbContext _context;
        public CoursesService(AppDbContext context) : base(context)
        {
        }
    }
}
