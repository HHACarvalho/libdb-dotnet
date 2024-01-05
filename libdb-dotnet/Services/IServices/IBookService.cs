using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBookService
    {
        Task<Operation<BookDTOFull>> CreateBook(BookRequestBody dto);
        Task<Operation<List<BookDTOFull>>> FindAllBooks(int pageNumber, int pageSize);
        Task<Operation<List<BookDTOFull>>> FindBooks(string bookTitle);
        Task<Operation<BookDTOFull>> FindOneBook(string bookID);
        Task<Operation<BookDTOFull>> UpdateBook(string bookID, BookRequestBody dto);
        Task<Operation<BookDTOFull>> DeleteBook(string bookID);
    }
}