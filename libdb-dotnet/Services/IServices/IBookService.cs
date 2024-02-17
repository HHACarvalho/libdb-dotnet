using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBookService
    {
        Task<Result> CreateBook(BookCreateBody requestBody);
        Task<Result> FindAllBooks(int pageNumber, int pageSize);
        Task<Result> FindBooks(string title);
        Task<Result> FindOneBook(int id);
        Task<Result> UpdateBook(BookUpdateBody requestBody);
        Task<Result> DeleteBook(int id);
    }
}