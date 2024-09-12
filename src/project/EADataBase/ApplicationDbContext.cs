using Core.EAApplication.MediatrRequestLogging;
using Core.EACrossCuttingConcerns.ExceptionLogging;
using Core.EADomain.Domains;
using Core.EAInfrastructure;
using Microsoft.EntityFrameworkCore;

namespace EADataBase
{
    public class ApplicationDbContext : DbContext
    {
        HashingAndGenerateToken _hashingAndGenerateToken;
        public ApplicationDbContext(DbContextOptions options, HashingAndGenerateToken hashingAndGenerateToken) : base(options)
        {
            _hashingAndGenerateToken = hashingAndGenerateToken;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public DbSet<LoggeableRequest> LoggeableRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<string> roles = new List<string>();
            roles.Add("Admin");

            string createPassword = _hashingAndGenerateToken.HashPassword("12345");

            //modelBuilder.Entity<User>().Property(u=>u.Roles).HasConversion(
            //    u=>string.Join(',',u),
            //    u=>u.Split(',',StringSplitOptions.RemoveEmptyEntries).ToList());

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email="ea@ea.com",
                FirstName="ea",
                LastName="ea",
                Password=createPassword,
                CreatedDate= DateTime.Now,
                DeletedDate=null,
                UpdatedDate=null,
                IsActive = true,
                Token=null
            });
            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim
            {
                Id = 1,
                Name = "SystemAdmin",
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                UpdatedDate = null,
            });
            modelBuilder.Entity<UserOperationClaim>().HasData(new UserOperationClaim
            {
                Id = 1,
                OperationClaimId = 1,
                UserId = 1,
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                UpdatedDate = null,
            });
        }
    }
}
