using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class BookRepo : CoreRepo<Book>, IBookRepo
    {
        public BookRepo(AppDBContext dbc) : base(dbc, dbc.Books) { }

        public async Task<QueryOutput<Book>> FindAll(int pageNumber, int pageSize)
        {
            var output = new QueryOutput<Book>(
                await _dbs.CountAsync(),
                await _dbs
                    .OrderByDescending(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Include(x => x.Author)
                    .ToArrayAsync()
            );

            return output;
        }

        public async Task<QueryOutput<Book>> Find(int pageNumber, int pageSize, int id, string? title, int year, string? genre, string? authorName)
        {
            IQueryable<Book> subSet = _dbs;

            if (id > 0)
            {
                subSet = subSet.Where(x => x.Id.Equals(id));
            }

            if (!string.IsNullOrEmpty(title))
            {
                subSet = subSet.Where(x => x.Title.Contains(title));
            }

            if (year > 0)
            {
                subSet = subSet.Where(x => x.Year.Equals(year));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                subSet = subSet.Where(x => x.Genre.Contains(genre));
            }

            subSet = subSet.Include(x => x.Author);

            if (!string.IsNullOrEmpty(authorName))
            {
                subSet = subSet.Where(x => x.Author.Name.Contains(authorName));
            }

            var output = new QueryOutput<Book>(
                await subSet.CountAsync(),
                await subSet
                    .OrderByDescending(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync()
            );

            return output;
        }

        public async Task<Book?> FindOne(int id)
        {
            return await _dbs
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Author)
                .Include(x => x.BookEntries)
                .FirstOrDefaultAsync();
        }
    }
}