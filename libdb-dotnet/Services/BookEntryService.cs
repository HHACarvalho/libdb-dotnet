using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.DTOs;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services.IServices;

namespace libdb_dotnet.Services
{
    public class BookEntryService : IBookEntryService
    {
        private readonly IBookRepo _bookRepo;
        private readonly IBookEntryRepo _bookEntryRepo;

        public BookEntryService(IBookRepo bookRepo, IBookEntryRepo bookEntryRepo)
        {
            _bookRepo = bookRepo;
            _bookEntryRepo = bookEntryRepo;
        }

        public async Task<Result<BookEntryDTOFull>> CreateBookEntry(BookEntryRequestBody requestBody)
        {
            var book = await _bookRepo.FindOne(requestBody.BookId);
            if (book == null)
            {
                return Result<BookEntryDTOFull>.Fail("Book not found");
            }

            var newBookEntry = new BookEntry
            {
                Isbn = requestBody.Isbn,
                Book = book
            };

            newBookEntry = await _bookEntryRepo.Create(newBookEntry);

            return Result<BookEntryDTOFull>.Success(BookEntryDTOFull.ToDTO(newBookEntry));
        }

        public async Task<Result<List<BookEntryDTOFull>>> FindAllBookEntries(int pageNumber, int pageSize)
        {
            var bookEntryList = pageNumber > 0 && pageSize > 0 ? await _bookEntryRepo.FindAll(pageNumber, pageSize) : await _bookEntryRepo.FindAll();
            if (bookEntryList.Count == 0)
            {
                return Result<List<BookEntryDTOFull>>.Fail("There are no book entries");
            }

            return Result<List<BookEntryDTOFull>>.Success(bookEntryList.ConvertAll(BookEntryDTOFull.ToDTO));
        }

        public async Task<Result<BookEntryDTOFull>> FindOneBookEntry(int id)
        {
            var bookEntry = await _bookEntryRepo.FindOne(id);
            if (bookEntry == null)
            {
                return Result<BookEntryDTOFull>.Fail("No book entry with the Id '" + id + "' was found");
            }

            return Result<BookEntryDTOFull>.Success(BookEntryDTOFull.ToDTO(bookEntry));
        }

        public async Task<Result<BookEntryDTOFull>> UpdateBookEntry(int id, BookEntryRequestBody requestBody)
        {
            var bookEntry = await _bookEntryRepo.FindOne(id);
            if (bookEntry == null)
            {
                return Result<BookEntryDTOFull>.Fail("No book entry with the Id '" + id + "' was found");
            }

            bookEntry.Isbn = requestBody.Isbn;

            await _bookEntryRepo.CommitChanges();

            return Result<BookEntryDTOFull>.Success(BookEntryDTOFull.ToDTO(bookEntry));
        }

        public async Task<Result<BookEntryDTOFull>> DeleteBookEntry(int id)
        {
            var bookEntry = await _bookEntryRepo.FindOne(id);
            if (bookEntry == null)
            {
                return Result<BookEntryDTOFull>.Fail("No book entry with the Id '" + id + "' was found");
            }

            await _bookEntryRepo.Delete(bookEntry);

            return Result<BookEntryDTOFull>.Success(BookEntryDTOFull.ToDTO(bookEntry));
        }
    }
}