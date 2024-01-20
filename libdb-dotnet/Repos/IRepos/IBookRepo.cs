using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IBookRepo : ICoreRepo<Book>
    {
        Task<List<Book>> Find(string title);
        Task<Book?> FindOne(string isbn);
    }
}