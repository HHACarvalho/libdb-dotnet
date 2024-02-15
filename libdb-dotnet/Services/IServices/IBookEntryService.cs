using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBookEntryService
    {
        Task<Result<BookEntryDTOFull>> CreateBookEntry(BookEntryRequestBody requestBody);
        Task<Result<List<BookEntryDTOFull>>> FindAllBookEntries(int pageNumber, int pageSize);
        Task<Result<BookEntryDTOFull>> FindOneBookEntry(int id);
        Task<Result<BookEntryDTOFull>> UpdateBookEntry(int id, BookEntryRequestBody requestBody);
        Task<Result<BookEntryDTOFull>> DeleteBookEntry(int id);
    }
}