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
                entity.HasOne(e => e.Match)
                    .WithMany(e => e.TeamList);
            });

            // Tournaments
            modelBuilder.Entity<Tournament>().ToTable("Tournaments");
            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(m => m.MatchList)
                    .WithOne(p => p.Tournament);
            });



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
