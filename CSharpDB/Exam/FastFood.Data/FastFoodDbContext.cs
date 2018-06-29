using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Data
{
	public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Position> Positions { get; set; }




        protected override void OnModelCreating(ModelBuilder m)
		{
            m.Entity<Category>().HasKey(c => c.Id);
            m.Entity<Category>().Property(c => c.Name).IsRequired(true);

            m.Entity<Employee>().HasKey(e => e.Id);
            m.Entity<Employee>().Property(e => e.Name).IsRequired(true);
            m.Entity<Employee>().Property(e => e.Age).IsRequired(true);
            m.Entity<Employee>().HasOne(e => e.Position).WithMany(p => p.Employees).HasForeignKey(e => e.PositionId).OnDelete(DeleteBehavior.Restrict);

            m.Entity<Item>().HasKey(i => i.Id);
            m.Entity<Item>().Property(i => i.Name).IsRequired(true);
            m.Entity<Item>().Property(i => i.Price).IsRequired(true);
            m.Entity<Item>().HasOne(i => i.Category).WithMany(c => c.Items).HasForeignKey(i => i.CategoryId).OnDelete(DeleteBehavior.Restrict);
            
            m.Entity<Order>().HasKey(o => o.Id);
            m.Entity<Order>().Property(o => o.Customer).IsRequired(true);
            m.Entity<Order>().Property(o => o.DateTime).IsRequired(true);
            m.Entity<Order>().Property(o => o.Type).IsRequired(true);
            m.Entity<Order>().Ignore(o => o.TotalPrice);
            m.Entity<Order>().HasOne(o => o.Employee).WithMany(e => e.Orders).HasForeignKey(o => o.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            
            m.Entity<OrderItem>().HasKey(oi => new { oi.OrderId, oi.ItemId});
            m.Entity<OrderItem>().Property(oi => oi.Quantity).IsRequired(true);
            m.Entity<OrderItem>().HasOne(oi => oi.Item).WithMany(oi => oi.OrderItems).HasForeignKey(oi => oi.ItemId);
            m.Entity<OrderItem>().HasOne(oi => oi.Order).WithMany(oi => oi.OrderItems).HasForeignKey(oi => oi.OrderId);

            m.Entity<Position>().HasKey(p => p.Id);
            m.Entity<Position>().Property(p => p.Name).IsRequired(true);



        }
    }
}