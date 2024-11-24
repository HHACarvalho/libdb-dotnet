using libdb_dotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Core
{
    public class AppDBContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookEntry> BookEntries { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Borrow> Borrows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrow>().Property(b => b.Fine).HasPrecision(18, 2);
        }
    }
}