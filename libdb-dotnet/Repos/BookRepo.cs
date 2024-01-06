using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class BookRepo : CoreRepo<Book>, IBookRepo
    {
        public BookRepo(AppDBContext dbc) : base(dbc, dbc.Books) { }

        public async Task<List<Book>> Find(string bookTitle)
        {
            return await _dbs.Where(x => x.Title.Contains(bookTitle)).ToListAsync();
        }

        public virtual async Task<Book?> FindOne(string bookIsbn)
        {
            return await _dbs.Where(x => x.Isbn.Equals(bookIsbn)).FirstOrDefaultAsync();
        }
    }
}