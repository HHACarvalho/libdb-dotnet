using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IAuthorService
    {
        Task<Result<AuthorDTOFull>> CreateAuthor(AuthorRequestBody dto);
        Task<Result<List<AuthorDTOFull>>> FindAllAuthors(int pageNumber, int pageSize);
        Task<Result<List<AuthorDTOFull>>> FindAuthors(string authorName);
        Task<Result<AuthorDTOFull>> FindOneAuthor(int authorId);
        Task<Result<AuthorDTOFull>> UpdateAuthor(int authorId, AuthorRequestBody dto);
        Task<Result<AuthorDTOFull>> DeleteAuthor(int authorId);
    }
}