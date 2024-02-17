using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBookEntryService
    {
        Task<Result> CreateBookEntry(BookEntryCreateBody requestBody);
        Task<Result> FindAllBookEntries(int pageNumber, int pageSize);
        Task<Result> FindOneBookEntry(int id);
        Task<Result> UpdateBookEntry(BookEntryUpdateBody requestBody);
        Task<Result> DeleteBookEntry(int id);
    }
}