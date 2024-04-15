using libdb_dotnet.Core;
using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IBookEntryRepo : ICoreRepo<BookEntry>
    {
        Task<QueryOutput<BookEntry>> FindAll(int pageNumber, int pageSize);
        Task<BookEntry?> FindOne(int id);
    }
}