using JobCandidateHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Candidate>().HasIndex(c => c.Email).IsUnique();  
        }
    }
}
