using libdb_dotnet.Core;
using libdb_dotnet.Domain;

namespace libdb_dotnet.Repos.IRepos
{
    public interface IBookRepo : ICoreRepo<Book>
    {
        Task<QueryOutput<Book>> FindAll(int pageNumber, int pageSize);
        Task<QueryOutput<Book>> Find(int pageNumber, int pageSize, int id, string? title, int year, string? genre, string? authorName);
        Task<Book?> FindOne(int id);
    }
}