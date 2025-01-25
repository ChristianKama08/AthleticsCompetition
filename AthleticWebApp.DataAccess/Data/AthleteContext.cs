using AthleticWebApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AthleticWebApp.DataAccess.Data
{
    public class AthleteContext : DbContext
    {
        public AthleteContext(DbContextOptions<AthleteContext> options) : base(options)
        {

        }

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Result>()
                .HasOne(c => c.Competition)
                .WithMany(c => c.Results)
                .HasForeignKey(co => co.CompetitionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
