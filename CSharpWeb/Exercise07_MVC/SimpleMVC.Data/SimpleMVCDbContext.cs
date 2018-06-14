namespace SimpleMVC.Data
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Domain;

    public class SimpleMVCDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

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
            mb.Entity<User>().Property(u => u.PasswordHash).HasColumnName("Password");

            mb.Entity<Note>().HasKey(n => n.Id);
            mb.Entity<Note>().HasOne(n => n.Owner)
                             .WithMany(u => u.Notes)
                             .HasForeignKey(n => n.UserId);
        }
    }
}