using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IMemberRepo : ICoreRepo<Member>
    {
        Task<List<Member>> Find(string name);
        Task<Member?> FindOne(int id);
    }
}