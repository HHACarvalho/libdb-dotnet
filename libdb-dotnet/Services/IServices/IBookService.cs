using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBookService
    {
        Task<Result> CreateBook(BookCreateBody requestBody);
        Task<Result> FindAllBooks(int pageNumber, int pageSize);
        Task<Result> FindBooks(int pageNumber, int pageSize, int id, string? title, int year, string? genre, string? authorName);
        Task<Result> FindOneBook(int id);
        Task<Result> UpdateBook(BookUpdateBody requestBody);
        Task<Result> DeleteBook(int id);
    }
}