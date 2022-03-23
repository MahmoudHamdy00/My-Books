using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My_Books.Data.Models;

namespace My_Books.Models
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>().HasOne(x => x.book).WithMany(x => x.book_Authors).HasForeignKey(x => x.bookId);
            modelBuilder.Entity<Book_Author>().HasOne(x => x.author).WithMany(x => x.book_Authors).HasForeignKey(x => x.authorId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> book_Authors { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
