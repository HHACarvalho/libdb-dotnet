using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IMemberRepo : ICoreRepo<Member>
    {
        Task<List<Member>> FindAll(int pageNumber = 1, int pageSize = 20);
        Task<List<Member>> Find(string name, int pageNumber = 1, int pageSize = 20);
        Task<Member?> FindOne(int id);
    }
}