using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBookService
    {
        Task<Result<BookDTOFull>> CreateBook(BookRequestBody requestBody);
        Task<Result<List<BookDTOFull>>> FindAllBooks(int pageNumber, int pageSize);
        Task<Result<List<BookDTOFull>>> FindBooks(string title);
        Task<Result<BookDTOFull>> FindOneBook(string id);
        Task<Result<BookDTOFull>> UpdateBook(string id, BookRequestBody requestBody);
        Task<Result<BookDTOFull>> DeleteBook(string id);
    }
}