using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBookEntryService
    {
        Task<Result> CreateBookEntry(BookEntryRequestBody requestBody);
        Task<Result> FindAllBookEntries(int pageNumber, int pageSize);
        Task<Result> FindOneBookEntry(int id);
        Task<Result> UpdateBookEntry(int id, BookEntryRequestBody requestBody);
        Task<Result> DeleteBookEntry(int id);
    }
}