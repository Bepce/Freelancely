using Freelancely.Infrastructure.Data.Models;
using Freelancely.Infrastructure.Data.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Freelancely.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguraiton());
            builder.ApplyConfiguration(new PostConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<WorkIndustry> WorkIndustry { get; set; }

    }
}
