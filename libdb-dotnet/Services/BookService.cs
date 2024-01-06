using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.DTOs;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services.IServices;

namespace libdb_dotnet.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _repo;

        public BookService(IBookRepo repo)
        {
            _repo = repo;
        }

        public async Task<Result<BookDTOFull>> CreateBook(BookRequestBody dto)
        {
            var newBook = new Book(dto.ISBN, dto.Title, dto.Author);

            await _repo.Create(newBook);

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(newBook));
        }

        public async Task<Result<List<BookDTOFull>>> FindAllBooks(int pageNumber, int pageSize)
        {
            var bookList = await _repo.FindAll(pageNumber != 0 ? pageNumber : 1, pageSize != 0 ? pageSize : 20);
            if (bookList.Count == 0)
            {
                return Result<List<BookDTOFull>>.Fail("There are no books");
            }

            return Result<List<BookDTOFull>>.Success(bookList.ConvertAll(BookDTOFull.ToDTO));
        }

        public async Task<Result<List<BookDTOFull>>> FindBooks(string bookTitle)
        {
            var bookList = await _repo.Find(bookTitle);
            if (bookList.Count == 0)
            {
                return Result<List<BookDTOFull>>.Fail("No books with '" + bookTitle + "' in the title were found");
            }

            return Result<List<BookDTOFull>>.Success(bookList.ConvertAll(BookDTOFull.ToDTO));
        }

        public async Task<Result<BookDTOFull>> FindOneBook(string bookIsbn)
        {
            var book = await _repo.FindOne(bookIsbn);
            if (book == null)
            {
                return Result<BookDTOFull>.Fail("No book with the ISBN '" + bookIsbn + "' was found");
            }

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }

        public async Task<Result<BookDTOFull>> UpdateBook(string bookIsbn, BookRequestBody dto)
        {
            var book = await _repo.FindOne(bookIsbn);
            if (book == null)
            {
                return Result<BookDTOFull>.Fail("No book with the ISBN '" + bookIsbn + "' was found");
            }

            book.Isbn = dto.ISBN;
            book.Title = dto.Title;
            book.Author = dto.Author;

            await _repo.CommitChanges();

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }

        public async Task<Result<BookDTOFull>> DeleteBook(string bookIsbn)
        {
            var book = await _repo.FindOne(bookIsbn);
            if (book == null)
            {
                return Result<BookDTOFull>.Fail("No book with the ISBN '" + bookIsbn + "' was found");
            }

            await _repo.Delete(book);

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }
    }
}