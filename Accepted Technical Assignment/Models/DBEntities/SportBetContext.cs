using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Accepted_Technical_Assignment.Models.DBEntities
{
    public partial class SportBetContext : DbContext
    {
        public SportBetContext()
        {
        }

        public SportBetContext(DbContextOptions<SportBetContext> options)
        : base(options)
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
        new Microsoft.Extensions.Logging.LoggerFactory(new[]
        {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }

        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchOdd> MatchOdds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.MatchDate).HasColumnType("date");

                entity.Property(e => e.MatchTime).HasColumnType("time(0)");

                entity.Property(e => e.TeamA).HasMaxLength(100);

                entity.Property(e => e.TeamB).HasMaxLength(100);
            });

            modelBuilder.Entity<MatchOdd>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Odd).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Specifier)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchOdds)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MatchOdds_Match");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}