using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class MemberRepo : CoreRepo<Member>, IMemberRepo
    {
        public MemberRepo(AppDBContext dbc) : base(dbc, dbc.Members) { }

        public async Task<List<Member>> FindAll(int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Member>> Find(string name, int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs
                .Where(x => x.Name.Contains(name))
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Member?> FindOne(int id)
        {
            return await _dbs
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Borrows)
                .ThenInclude(x => x.BookEntry)
                .ThenInclude(x => x.Book)
                .FirstOrDefaultAsync();
        }
    }
}