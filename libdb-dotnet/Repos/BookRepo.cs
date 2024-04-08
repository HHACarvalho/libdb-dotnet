using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class BookRepo : CoreRepo<Book>, IBookRepo
    {
        public BookRepo(AppDBContext dbc) : base(dbc, dbc.Books) { }

        public override async Task<List<Book>> FindAll(int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Author)
                .ToListAsync();
        }

        public async Task<List<Book>> Find(string title)
        {
            return await _dbs
                .Where(x => x.Title.Contains(title))
                .Include(x => x.Author)
                .ToListAsync();
        }

        public async Task<Book?> FindOne(int id)
        {
            return await _dbs
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Author)
                .Include(x => x.BookEntries)
                .FirstOrDefaultAsync();
        }
    }
}