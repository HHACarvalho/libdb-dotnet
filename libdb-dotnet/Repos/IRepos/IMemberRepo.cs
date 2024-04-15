using libdb_dotnet.Core;
using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IMemberRepo : ICoreRepo<Member>
    {
        Task<QueryOutput<Member>> FindAll(int pageNumber, int pageSize);
        Task<QueryOutput<Member>> Find(int pageNumber, int pageSize, int id, string? memberName, string? email, string? address, string? phoneNumber);
        Task<Member?> FindOne(int id);
    }
}