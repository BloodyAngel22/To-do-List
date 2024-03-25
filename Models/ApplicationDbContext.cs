using Microsoft.EntityFrameworkCore;

namespace To_do_List.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{ }

		public DbSet<TaskModel> Tasks { get; set; }
	}
}