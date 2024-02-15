using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IBorrowRepo : ICoreRepo<Borrow>
    {
        Task<Borrow?> FindOne(int id);
    }
}