using Microsoft.EntityFrameworkCore;
using MemoryGame.Entities;

namespace MemoryGame.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<PlayerEntity> Players { get; set; }
    }
}