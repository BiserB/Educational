using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class BookLibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=OurLibrary; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Book>().HasKey(b => b.Id);
            mb.Entity<Book>().HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);
            mb.Entity<Book>().HasOne(b => b.Category).WithMany(c => c.Books).HasForeignKey(b => b.CategoryId);
            mb.Entity<Book>().HasOne(b => b.Status).WithMany(s => s.Books).HasForeignKey(b => b.StatusId);

            mb.Entity<Status>().HasKey(s => s.Id);
            mb.Entity<Status>().HasData(new Status { Id = 1, Name = "At home" });
            mb.Entity<Status>().HasData(new Status { Id = 2, Name = "Borrowed" });

            mb.Entity<Author>().HasKey(a => a.Id);

            mb.Entity<Borrower>().HasKey(b => b.Id);

            mb.Entity<Loan>().HasKey(l => l.Id);
            mb.Entity<Loan>().HasOne(l => l.Borrower).WithMany(b => b.Loans).HasForeignKey(l => l.BorrowerId);
            mb.Entity<Loan>().HasOne(l => l.Book).WithMany(b => b.Loans).HasForeignKey(l => l.BookId);
            

            mb.Entity<Category>().HasKey(c => c.Id);
        }
    }
}