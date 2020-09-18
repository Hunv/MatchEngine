using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchEngine.DatabaseModel
{
    public class MyDbContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Team2Match> Teams2Matches { get; set; }
        public DbSet<Team2Tournament> Teams2Tournaments { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Setting> Settings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MatchEngine.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            // Teams to Tournaments
            modelBuilder.Entity<Team2Tournament>().ToTable("Teams2Tournaments");
            modelBuilder.Entity<Team2Tournament>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.TournamentId });
                entity.HasOne(e => e.Team)
                    .WithMany(e => e.TournamentList);
                entity.HasOne(e => e.Tournament)
                    .WithMany(e => e.TeamList);
            });

            // Teams to Matches
            modelBuilder.Entity<Team2Match>().ToTable("Teams2Matches");
            modelBuilder.Entity<Team2Match>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.MatchId });
                entity.HasOne(e => e.Team)
                    .WithMany(e => e.MatchList);
            });

            // Tournaments
            modelBuilder.Entity<Tournament>().ToTable("Tournaments");
            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(m => m.MatchList)
                    .WithOne(p => p.Tournament);
            });

            //base.OnModelCreating(modelBuilder);
        }
    }
}
