using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IAuthorService
    {
        Task<Result<AuthorDTOFull>> CreateAuthor(AuthorRequestBody dto);
        Task<Result<List<AuthorDTOFull>>> FindAllAuthors(int pageNumber, int pageSize);
        Task<Result<List<AuthorDTOFull>>> FindAuthors(string authorName);
        Task<Result<AuthorDTOFull>> FindOneAuthor(string authorId);
        Task<Result<AuthorDTOFull>> UpdateAuthor(string authorId, AuthorRequestBody dto);
        Task<Result<AuthorDTOFull>> DeleteAuthor(string authorId);
    }
}