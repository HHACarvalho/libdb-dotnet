using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBookService
    {
        Task<Result> CreateBook(BookRequestBody requestBody);
        Task<Result> FindAllBooks(int pageNumber, int pageSize);
        Task<Result> FindBooks(string title);
        Task<Result> FindOneBook(int id);
        Task<Result> UpdateBook(int id, BookRequestBody requestBody);
        Task<Result> DeleteBook(int id);
    }
}