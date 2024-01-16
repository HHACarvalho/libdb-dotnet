using libdb_dotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Core
{
    public class AppDBContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add custom configurations for entities
        }
    }
}