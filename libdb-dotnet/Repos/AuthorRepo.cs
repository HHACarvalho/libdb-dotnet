using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class AuthorRepo : CoreRepo<Author>, IAuthorRepo
    {
        public AuthorRepo(AppDBContext dbc) : base(dbc, dbc.Authors) { }

        public async Task<QueryOutput<Author>> FindAll(int pageNumber, int pageSize)
        {
            var output = new QueryOutput<Author>(
                await _dbs.CountAsync(),
                await _dbs
                    .OrderByDescending(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync()
            );

            return output;
        }

        public async Task<QueryOutput<Author>> Find(int pageNumber, int pageSize, int id, string? authorName)
        {
            IQueryable<Author> subSet = _dbs;

            if (id > 0)
            {
                subSet = subSet.Where(x => x.Id.Equals(id));
            }

            if (!string.IsNullOrEmpty(authorName))
            {
                subSet = subSet.Where(x => x.Name.Contains(authorName));
            }

            var output = new QueryOutput<Author>(
                await subSet.CountAsync(),
                await subSet
                    .OrderByDescending(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync()
            );

            return output;
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