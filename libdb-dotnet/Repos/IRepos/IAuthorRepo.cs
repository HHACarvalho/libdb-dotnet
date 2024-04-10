using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IAuthorRepo : ICoreRepo<Author>
    {
        Task<List<Author>> FindAll(int pageNumber = 1, int pageSize = 20);
        Task<List<Author>> Find(string name, int pageNumber = 1, int pageSize = 20);
        Task<Author?> FindOne(int id);
    }
}