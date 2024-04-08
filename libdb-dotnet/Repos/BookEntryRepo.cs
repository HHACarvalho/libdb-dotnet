using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class BookEntryRepo : CoreRepo<BookEntry>, IBookEntryRepo
    {
        public BookEntryRepo(AppDBContext dbc) : base(dbc, dbc.BookEntries) { }

        public async Task<BookEntry?> FindOne(int id)
        {
            return await _dbs
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Book)
                .FirstOrDefaultAsync();
        }
    }
}