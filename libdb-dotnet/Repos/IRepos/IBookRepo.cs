using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IBookRepo : ICoreRepo<Book>
    {
        Task<List<Book>> FindAll(int pageNumber = 1, int pageSize = 20);
        Task<List<Book>> Find(string title, int pageNumber = 1, int pageSize = 20);
        Task<Book?> FindOne(int id);
    }
}