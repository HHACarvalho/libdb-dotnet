using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class AuthorRepo : CoreRepo<Author>, IAuthorRepo
    {
        public AuthorRepo(AppDBContext dbc) : base(dbc, dbc.Authors) { }

        public async Task<List<Author>> FindAll(int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Author>> Find(string name, int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs
                .Where(x => x.Name.Contains(name))
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Author?> FindOne(int id)
        {
            return await _dbs
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Books)
                .FirstOrDefaultAsync();
        }
    }
}