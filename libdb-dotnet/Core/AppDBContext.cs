using libdb_dotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Core
{
    public class AppDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public AppDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}