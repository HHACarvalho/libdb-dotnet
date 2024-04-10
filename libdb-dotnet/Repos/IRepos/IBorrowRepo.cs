using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IBorrowRepo : ICoreRepo<Borrow>
    {
        Task<List<Borrow>> FindAll(int pageNumber = 1, int pageSize = 20);
        Task<Borrow?> FindOne(int id);
    }
}