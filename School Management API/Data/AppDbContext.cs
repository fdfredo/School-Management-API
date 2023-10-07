using Microsoft.EntityFrameworkCore;
using School_Management_API.Models;

namespace School_Management_API.Data
{
	public class AppDbContext:DbContext 
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Result>()
				.HasOne(r => r.Students)
				.WithMany(s => s.Results)
				.HasForeignKey(r => r.StudentId)
				.OnDelete(DeleteBehavior.NoAction);

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Exam> Exams { get; set; }
		public DbSet<Result> Results { get; set; }
		public DbSet<Administration> Administrations { get; set; }
		public DbSet<Faculty> Faculties { get; set; }
		public DbSet<Admission> Admissions { get; set; }
		public DbSet<Curriculum> Curricula { get; set; }
	}
}
