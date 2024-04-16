using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class BookEntryRepo : CoreRepo<BookEntry>, IBookEntryRepo
    {
        public BookEntryRepo(AppDBContext dbc) : base(dbc, dbc.BookEntries) { }

        public async Task<QueryOutput<BookEntry>> FindAll(int pageNumber, int pageSize)
        {
            var output = new QueryOutput<BookEntry>(
                await _dbs.CountAsync(),
                await _dbs
                    .OrderByDescending(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync()
            );

            return output;
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