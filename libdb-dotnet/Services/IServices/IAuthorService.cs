using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IAuthorService
    {
        Task<Result<AuthorDTOFull>> CreateAuthor(AuthorRequestBody requestBody);
        Task<Result<List<AuthorDTOFull>>> FindAllAuthors(int pageNumber, int pageSize);
        Task<Result<List<AuthorDTOFull>>> FindAuthors(string name);
        Task<Result<AuthorDTOFull>> FindOneAuthor(int id);
        Task<Result<AuthorDTOFull>> UpdateAuthor(int id, AuthorRequestBody requestBody);
        Task<Result<AuthorDTOFull>> DeleteAuthor(int id);
    }
}