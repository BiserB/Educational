using HTTPServer.ByTheCakeApplication.Models;
using HTTPServer.ByTheCakeApplication.Utilities;
using Microsoft.EntityFrameworkCore;

namespace HTTPServer.ByTheCakeApplication.Data
{
    public class ByTheCakeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>().HasKey(u => u.Id);

            mb.Entity<Product>().HasKey(p => p.Id);

            mb.Entity<Order>().HasKey(o => o.Id);
            mb.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);

            mb.Entity<ProductOrder>().HasKey(po => new { po.ProductId, po.OrderId });
            mb.Entity<ProductOrder>().HasOne(po => po.Product)
                                     .WithMany(p => p.ProductOrders)
                                     .HasForeignKey(po => po.ProductId);
            mb.Entity<ProductOrder>().HasOne(po => po.Order)
                                     .WithMany(o => o.ProductList)
                                     .HasForeignKey(po => po.OrderId);
        }
    }
}