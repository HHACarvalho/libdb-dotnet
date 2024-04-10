using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class BookEntryRepo : CoreRepo<BookEntry>, IBookEntryRepo
    {
        public BookEntryRepo(AppDBContext dbc) : base(dbc, dbc.BookEntries) { }

        public async Task<List<BookEntry>> FindAll(int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<BookEntry?> FindOne(int id)
        {
            return await _dbs
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Book)
                .FirstOrDefaultAsync();
        }
    }
}