using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBookService
    {
        Task<Result<BookDTOFull>> CreateBook(BookRequestBody dto);
        Task<Result<List<BookDTOFull>>> FindAllBooks(int pageNumber, int pageSize);
        Task<Result<List<BookDTOFull>>> FindBooks(string bookTitle);
        Task<Result<BookDTOFull>> FindOneBook(string bookIsbn);
        Task<Result<BookDTOFull>> UpdateBook(string bookIsbn, BookRequestBody dto);
        Task<Result<BookDTOFull>> DeleteBook(string bookIsbn);
    }
}