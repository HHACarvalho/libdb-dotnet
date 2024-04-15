using libdb_dotnet.Core;
using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IAuthorRepo : ICoreRepo<Author>
    {
        Task<QueryOutput<Author>> FindAll(int pageNumber, int pageSize);
        Task<QueryOutput<Author>> Find(int pageNumber, int pageSize, int id, string? authorName);
        Task<Author?> FindOne(int id);
    }
}