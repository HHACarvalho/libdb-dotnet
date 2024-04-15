using libdb_dotnet.Core;
using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IBorrowRepo : ICoreRepo<Borrow>
    {
        Task<QueryOutput<Borrow>> FindAll(int pageNumber, int pageSize);
        Task<Borrow?> FindOne(int id);
    }
}