using FDMC.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace FDMC.Data
{
    public class FDMCDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FDMC_new;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Cat>().HasKey(c => c.Id);
        }
    }
}