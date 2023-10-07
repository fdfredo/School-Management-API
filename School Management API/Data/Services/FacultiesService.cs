using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class FacultiesService:EntityBaseRepository<Faculty>, IFacultiesService
	{
		private readonly AppDbContext _context;
        public FacultiesService(AppDbContext context) :base(context)
        {
        }
    }
}
