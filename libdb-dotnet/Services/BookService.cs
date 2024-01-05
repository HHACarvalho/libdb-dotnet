using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.DTOs;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services.IServices;

namespace libdb_dotnet.Services
{
    public class BookService(IBookRepo repo) : IBookService
    {
        private readonly IBookRepo _repo = repo;

        public async Task<Operation<BookDTOFull>> CreateBook(BookRequestBody dto)
        {
            var newBook = new Book(dto.ISBN, dto.Title, dto.Author);

            await _repo.Create(newBook);

            return Operation<BookDTOFull>.Success(BookDTOFull.ToDTO(newBook));
        }

        public async Task<Operation<List<BookDTOFull>>> FindAllBooks(int pageNumber, int pageSize)
        {
            var bookList = await _repo.FindAll(pageNumber != 0 ? pageNumber : 1, pageSize != 0 ? pageSize : 20);
            if (bookList.Count == 0)
            {
                return Operation<List<BookDTOFull>>.Fail("There are no books");
            }

            return Operation<List<BookDTOFull>>.Success(bookList.ConvertAll(BookDTOFull.ToDTO));
        }

        public async Task<Operation<List<BookDTOFull>>> FindBooks(string bookTitle)
        {
            var bookList = await _repo.Find(bookTitle);
            if (bookList.Count == 0)
            {
                return Operation<List<BookDTOFull>>.Fail("No books with '" + bookTitle + "' in the title were found");
            }

            return Operation<List<BookDTOFull>>.Success(bookList.ConvertAll(BookDTOFull.ToDTO));
        }

        public async Task<Operation<BookDTOFull>> FindOneBook(string bookID)
        {
            var book = await _repo.FindOne(bookID);
            if (book == null)
            {
                return Operation<BookDTOFull>.Fail("No book with the id '" + bookID + "' was found");
            }

            return Operation<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }

        public async Task<Operation<BookDTOFull>> UpdateBook(string bookID, BookRequestBody dto)
        {
            var book = await _repo.FindOne(bookID);
            if (book == null)
            {
                return Operation<BookDTOFull>.Fail("No book with the id '" + bookID + "' was found");
            }

            book.ISBN = dto.ISBN;
            book.Title = dto.Title;
            book.Author = dto.Author;

            await _repo.CommitChanges();

            return Operation<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }

        public async Task<Operation<BookDTOFull>> DeleteBook(string bookID)
        {
            var book = await _repo.FindOne(bookID);
            if (book == null)
            {
                return Operation<BookDTOFull>.Fail("No book with the id '" + bookID + "' was found");
            }

            await _repo.Delete(book);

            return Operation<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }
    }
}