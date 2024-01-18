using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class AuthorRepo : CoreRepo<Author>, IAuthorRepo
    {
        public AuthorRepo(AppDBContext dbc) : base(dbc, dbc.Authors) { }

        public async Task<List<Author>> Find(string authorName)
        {
            return await _dbs.Where(x => x.Name.Contains(authorName)).ToListAsync();
        }

        public virtual async Task<Author?> FindOne(string authorId)
        {
            return await _dbs.Where(x => x.Id.Equals(authorId)).FirstOrDefaultAsync();
        }
    }
}