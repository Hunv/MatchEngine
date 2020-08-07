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
        //public DbSet<StandaloneMatch> StandaloneMatch { get; set; }
        //public DbSet<StandaloneTeam> StandaloneTeams { get; set; }

        //public DbSet<Club> Clubs { get; set; }
        //public DbSet<MatchConfiguration> MatchConfigurations { get; set; }
        //public DbSet<MatchGoal> MatchGoals { get; set; }
        //public DbSet<MatchHalftime> MatchHalftimes { get; set; }
        //public DbSet<MatchInfo> MatchInfos { get; set; }
        //public DbSet<MatchPlayer> MatchPlayers { get; set; }
        //public DbSet<MatchTeam> MatchTeams { get; set; }
        //public DbSet<Player> Players { get; set; }
        //public DbSet<Tournament> Tournaments { get; set; }
        //public DbSet<TournamentPlayer> TournamentPlayers { get; set; }
        //public DbSet<TournamentTeam> TournamentTeams { get; set; }

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
            //// Map table names
            //modelBuilder.Entity<Club>().ToTable("Clubs");
            //modelBuilder.Entity<Club>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    //entity.HasIndex(e => e.Name).IsUnique();
            //    //entity.Property(e => e.Shortname);
            //    //entity.Property(e => e.Displayname);
            //    //entity.Property(e => e.DateTimeAdd).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //});

            //modelBuilder.Entity<Player>().ToTable("Players");
            //modelBuilder.Entity<Player>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});

            //modelBuilder.Entity<TournamentPlayer>().ToTable("TournamentPlayers");
            //modelBuilder.Entity<TournamentPlayer>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});

            //modelBuilder.Entity<MatchPlayer>().ToTable("MatchPlayers");
            //modelBuilder.Entity<MatchPlayer>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});

            //modelBuilder.Entity<TournamentTeam>().ToTable("TournamentTeams");
            //modelBuilder.Entity<TournamentTeam>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.HasMany(m => m.PlayerList)
            //        .WithOne(p => p.Team);
            //});

            //modelBuilder.Entity<MatchTeam>().ToTable("MatchTeams");
            //modelBuilder.Entity<MatchTeam>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});

            //modelBuilder.Entity<Tournament>().ToTable("Tournaments");
            //modelBuilder.Entity<Tournament>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.HasMany(m => m.TeamList)
            //        .WithOne(p => p.Tournament);
            //});


            //modelBuilder.Entity<MatchGoal>().ToTable("MatchGoals");
            //modelBuilder.Entity<MatchGoal>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});


            //modelBuilder.Entity<MatchHalftime>().ToTable("MatchHalftimes");
            //modelBuilder.Entity<MatchHalftime>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});

            //modelBuilder.Entity<MatchConfiguration>().ToTable("MatchConfigurations");
            //modelBuilder.Entity<MatchConfiguration>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.HasMany(m => m.Halftimes)
            //        .WithOne(p => p.Match);
            //});

            //modelBuilder.Entity<MatchInfo>().ToTable("MatchInfos");
            //modelBuilder.Entity<MatchInfo>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.HasMany(m => m.Team1Score)
            //        .WithOne(p => p.MatchTeam1);
            //    entity.HasMany(m => m.Team2Score)
            //        .WithOne(p => p.MatchTeam2);
            //    entity.HasMany(m => m.RefereeList)
            //        .WithOne(p => p.RefereeMatch);
            //});


            //modelBuilder.Entity<StandaloneMatch>().ToTable("StandaloneMatch");
            //modelBuilder.Entity<StandaloneMatch>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.HasMany(e => e.Teams)
            //        .WithOne(p => p.StandaloneMatch);
                
            //});


            //modelBuilder.Entity<StandaloneTeam>().ToTable("StandaloneTeams");
            //modelBuilder.Entity<StandaloneTeam>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});

            //base.OnModelCreating(modelBuilder);
        }
    }
}
