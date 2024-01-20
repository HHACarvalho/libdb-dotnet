using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IAuthorRepo : ICoreRepo<Author>
    {
        Task<List<Author>> Find(string name);
        Task<Author?> FindOne(int id);
    }
}