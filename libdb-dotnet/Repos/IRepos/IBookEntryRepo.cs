using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IBookEntryRepo : ICoreRepo<BookEntry>
    {
        Task<BookEntry?> FindOne(int id);
    }
}