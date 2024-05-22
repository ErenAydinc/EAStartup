using EACrossCuttingConcerns.ExceptionLogging;
using EASecurity.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EADataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u=>u.Roles).HasConversion(
                u=>string.Join(',',u),
                u=>u.Split(',',StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}
