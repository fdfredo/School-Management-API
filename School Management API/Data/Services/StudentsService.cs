using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class StudentsService : EntityBaseRepository<Student>, IStudentsService
	{
		private readonly AppDbContext _context;
        public StudentsService(AppDbContext context) : base(context)
        {
        }
    }
}
