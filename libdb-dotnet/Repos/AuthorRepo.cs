using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class AuthorRepo : CoreRepo<Author>, IAuthorRepo
    {
        public AuthorRepo(AppDBContext dbc) : base(dbc, dbc.Authors) { }

        public async Task<List<Author>> Find(string name)
        {
            return await _dbs.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<Author?> FindOne(int id)
        {
            return await _dbs.Where(x => x.Id.Equals(id)).Include(x => x.Books).FirstOrDefaultAsync();
        }
    }
}