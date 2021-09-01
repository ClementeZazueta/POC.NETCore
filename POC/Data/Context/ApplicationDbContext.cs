using Microsoft.EntityFrameworkCore;
using POC_Models.Models;
using POC_Data.Config;

namespace POC_Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Toys> Toys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToysConfig());
        }
    }
}
