using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IAuthorService
    {
        Task<Result> CreateAuthor(AuthorCreateRequestBody requestBody);
        Task<Result> FindAllAuthors(int pageNumber, int pageSize);
        Task<Result> FindAuthors(string name);
        Task<Result> FindOneAuthor(int id);
        Task<Result> UpdateAuthor(int id, AuthorCreateRequestBody requestBody);
        Task<Result> DeleteAuthor(int id);
    }
}