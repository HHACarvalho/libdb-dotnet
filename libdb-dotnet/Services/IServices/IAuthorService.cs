using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IAuthorService
    {
        Task<Result> CreateAuthor(AuthorCreateBody requestBody);
        Task<Result> FindAllAuthors(int pageNumber, int pageSize);
        Task<Result> FindAuthors(int pageNumber, int pageSize, int id, string? authorName);
        Task<Result> FindOneAuthor(int id);
        Task<Result> UpdateAuthor(AuthorUpdateBody requestBody);
        Task<Result> DeleteAuthor(int id);
    }
}