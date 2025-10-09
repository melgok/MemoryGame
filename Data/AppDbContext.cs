using Microsoft.EntityFrameworkCore;
using MemoryGame.Entities;

namespace MemoryGame.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<PlayerEntity> Players { get; set; }

        public DbSet<GameEntity> Games { get; set; }

        public DbSet<ScoreEntity> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerEntity>()
                .HasKey(e => e.PlayerId);

            modelBuilder.Entity<GameEntity>()
                .HasKey(e => e.GameId);

            modelBuilder.Entity<ScoreEntity>()
                .HasKey(e => new { e.PlayerId, e.GameId });

            modelBuilder.Entity<ScoreEntity>()
                .HasOne(e => e.Player)
                .WithMany(e => e.Scores)
                .HasForeignKey(e => e.PlayerId);

            modelBuilder.Entity<ScoreEntity>()
                .HasOne(e => e.Game)
                .WithMany(e => e.Scores)
                .HasForeignKey(e => e.GameId);

            modelBuilder.Entity<GameEntity>()
                .HasOne(e => e.CurrentPlayer)
                .WithMany(e => e.CurrentGames)
                .HasForeignKey(e => e.CurrentPlayerId);

            modelBuilder.Entity<GameEntity>()
                .HasOne(e => e.WinnerPlayer)
                .WithMany(e => e.WonGames)
                .HasForeignKey(e => e.WinnerPlayerId);
        }
    } 
}