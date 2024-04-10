using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class BorrowRepo : CoreRepo<Borrow>, IBorrowRepo
    {
        public BorrowRepo(AppDBContext dbc) : base(dbc, dbc.Borrows) { }

        public async Task<List<Borrow>> FindAll(int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.BookEntry)
                .ThenInclude(x => x.Book)
                .Include(x => x.Member)
                .ToListAsync();
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