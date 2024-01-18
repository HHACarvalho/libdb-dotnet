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

        public async Task<Result<BookDTOFull>> CreateBook(BookRequestBody dto)
        {
            var book = await _repo.FindOne(dto.Isbn);
            if (book != null)
            {
                return Result<BookDTOFull>.Fail("A book with the ISBN '" + dto.Isbn + "' already exists");
            }

            var newBook = new Book(dto.Isbn, dto.Title, dto.Author);

            await _repo.Create(newBook);

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(newBook));
        }

        public async Task<Result<List<BookDTOFull>>> FindAllBooks(int pageNumber, int pageSize)
        {
            var bookList = pageNumber > 0 && pageSize > 0 ? await _repo.FindAll(pageNumber, pageSize) : await _repo.FindAll();
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
                return Result<List<BookDTOFull>>.Fail("No books with a title containing '" + bookTitle + "' were found");
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

            book.Isbn = dto.Isbn;
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