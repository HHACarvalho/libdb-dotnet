using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class BorrowRepo : CoreRepo<Borrow>, IBorrowRepo
    {
        public BorrowRepo(AppDBContext dbc) : base(dbc, dbc.Borrows) { }

        public async Task<QueryOutput<Borrow>> FindAll(int pageNumber, int pageSize)
        {
            var output = new QueryOutput<Borrow>(
                await _dbs.CountAsync(),
                await _dbs
                    .OrderByDescending(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Include(x => x.BookEntry)
                    .ThenInclude(x => x.Book)
                    .Include(x => x.Member)
                    .ToArrayAsync()
            );

            return output;
        }

        public async Task<Borrow?> FindOne(int id)
        {
            return await _dbs
                .Where(x => x.Id.Equals(id))
                .Include(x => x.BookEntry)
                .ThenInclude(x => x.Book)
                .Include(x => x.Member)
                .FirstOrDefaultAsync();
        }
    }
}