namespace MyTube.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyTube.Models;

    public class MyTubeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Tube> Tubes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>().HasKey(u => u.Id);
            mb.Entity<User>().HasIndex(u => u.Username).IsUnique();

            mb.Entity<Tube>().HasKey(t => t.Id);
        }
    }
}