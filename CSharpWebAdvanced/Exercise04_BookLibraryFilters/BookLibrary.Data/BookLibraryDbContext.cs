using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class BookLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<BookLoan> BookLoans { get; set; }

        public DbSet<MovieLoan> MovieLoans { get; set; }

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
            mb.Entity<Book>().HasOne(b => b.Status).WithMany().HasForeignKey(b => b.StatusId);

            mb.Entity<Movie>().HasKey(m => m.Id);
            mb.Entity<Movie>().HasOne(m => m.Director).WithMany(d => d.Movies).HasForeignKey(m => m.DirectorId);
            mb.Entity<Movie>().HasOne(m => m.Status).WithMany().HasForeignKey(m => m.StatusId);

            mb.Entity<Status>().HasKey(s => s.Id);
            mb.Entity<Status>().HasData(new Status { Id = 1, Name = "At home" });
            mb.Entity<Status>().HasData(new Status { Id = 2, Name = "Borrowed" });

            mb.Entity<Author>().HasKey(a => a.Id);

            mb.Entity<Director>().HasKey(d => d.Id);

            mb.Entity<Borrower>().HasKey(b => b.Id);

            mb.Entity<BookLoan>().HasKey(l => l.Id);
            mb.Entity<BookLoan>().HasOne(l => l.Borrower).WithMany(b => b.Loans).HasForeignKey(l => l.BorrowerId);
            mb.Entity<BookLoan>().HasOne(l => l.Book).WithMany(b => b.Loans).HasForeignKey(l => l.BookId);

            mb.Entity<MovieLoan>().HasKey(l => l.Id);
            mb.Entity<MovieLoan>().HasOne(l => l.Borrower).WithMany(b => b.MovieLoans).HasForeignKey(l => l.BorrowerId);
            mb.Entity<MovieLoan>().HasOne(l => l.Movie).WithMany(m => m.MovieLoans).HasForeignKey(l => l.MovieId);

            mb.Entity<User>().HasKey(u => u.Id);
            mb.Entity<User>().HasIndex(u => u.Username).IsUnique();
            mb.Entity<User>().Property(u => u.PasswordHash).HasColumnType("char(64)").HasColumnName("Password");
            mb.Entity<User>().HasData(new User { Id = 1, Username = "admin", PasswordHash = "D74FF0EE8DA3B9806B18C877DBF29BBDE50B5BD8E4DAD7A3A725000FEB82E8F1" });
            //-------------------------------------------username:admin-----password:pass--------
        }
    }
}