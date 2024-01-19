using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IAuthorRepo : ICoreRepo<Author>
    {
        Task<List<Author>> Find(string authorName);
        Task<Author?> FindOne(int authorId);
    }
}