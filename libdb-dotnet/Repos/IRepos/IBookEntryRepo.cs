using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IBookEntryRepo : ICoreRepo<BookEntry>
    {
        Task<List<BookEntry>> FindAll(int pageNumber = 1, int pageSize = 20);
        Task<BookEntry?> FindOne(int id);
    }
}