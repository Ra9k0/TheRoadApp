using System.Reflection;

namespace TheRoadApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using TheRoadApp.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
	    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		    : base(options)
	    {
	    }

	    public DbSet<Tour> Tours { get; set; }

	    public DbSet<Comment> Comments { get; set; }

		public DbSet<Booking> Booking { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Booking>()
				.HasKey(x => new { x.TourId, x.UserId });

		    Assembly configAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext)) ??
		                              Assembly.GetExecutingAssembly();
		    builder.ApplyConfigurationsFromAssembly(configAssembly);

			base.OnModelCreating(builder);
	    }
    }
}
