using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class BookRepo(AppDBContext dbc) : CoreRepo<Book>(dbc, dbc.Books), IBookRepo
    {
        public async Task<List<Book>> Find(string bookTitle)
        {
            return await _dbs.Where(x => x.Title.Contains(bookTitle)).ToListAsync();
        }
    }
}