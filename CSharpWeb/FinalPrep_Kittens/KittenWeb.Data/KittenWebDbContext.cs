
namespace KittenWeb.Data
{
    using KittenWeb.Models;
    using Microsoft.EntityFrameworkCore;

    public class KittenWebDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Kitten> Kittens { get; set; }
        public DbSet<Breed> Breeds { get; set; }
         

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

            mb.Entity<Kitten>().HasKey(k => k.Id);
            mb.Entity<Kitten>().HasOne(k => k.Breed)
                               .WithMany(b => b.Kittens)
                               .HasForeignKey(k => k.BreedId);

            mb.Entity<Breed>().HasKey(b => b.Id);
            mb.Entity<Breed>().HasIndex(b => b.Type).IsUnique();
            mb.Entity<Breed>().HasData(new Breed { Id = 1, Type = "Street Transcended", ImageUrl = "/Images/street-transcended.jpg" });
            mb.Entity<Breed>().HasData(new Breed { Id = 2, Type = "American Shorthair", ImageUrl = "/Images/american-shorthair.jpg" });
            mb.Entity<Breed>().HasData(new Breed { Id = 3, Type = "Munchkin", ImageUrl = "/Images/munchkin.jpg" });
            mb.Entity<Breed>().HasData(new Breed { Id = 4, Type = "Siamese", ImageUrl = "/Images/siamese.jpg" });
        }
    }
}
