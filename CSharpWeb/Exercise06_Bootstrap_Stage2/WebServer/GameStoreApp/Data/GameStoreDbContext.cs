namespace HTTPServer.GameStoreApp.Data
{
    using HTTPServer.GameStoreApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class GameStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<UserGame> UserGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server =.;Database = GameStore;Trusted_Connection = True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>().HasKey(u => u.Id);

            mb.Entity<Game>().HasKey(g => g.Id);

            mb.Entity<UserGame>().HasKey(ug => new { ug.UserId, ug.GameId });
            mb.Entity<UserGame>().HasOne(ug => ug.User)
                                 .WithMany(u => u.Games)
                                 .HasForeignKey(ug => ug.UserId);

            mb.Entity<UserGame>().HasOne(ug => ug.Game)
                                 .WithMany(u => u.Users)
                                 .HasForeignKey(ug => ug.GameId);
        }
    }
}