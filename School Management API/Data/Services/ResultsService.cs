using School_Management_API.Data.Base;
using School_Management_API.Models;

namespace School_Management_API.Data.Services
{
	public class ResultsService : EntityBaseRepository<Result>, IResultsService
	{
		private readonly AppDbContext _context;
        public ResultsService(AppDbContext context) : base(context)
        {
        }
    }
}
