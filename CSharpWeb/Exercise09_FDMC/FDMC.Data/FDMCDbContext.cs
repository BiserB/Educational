
namespace FDMC.Data
{
    using FDMC.Models;
    using Microsoft.EntityFrameworkCore;


    public class FDMCDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Kitten> Cats { get; set; }

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
            mb.Entity<User>().HasIndex(u => u.Username)
                             .IsUnique();

            mb.Entity<Kitten>().HasKey(k => k.Id);
            mb.Entity<Kitten>().HasOne(k => k.Owner)
                               .WithMany(u => u.OwnedCats)
                               .HasForeignKey(k => k.OwnerId);

        }
    }
}
