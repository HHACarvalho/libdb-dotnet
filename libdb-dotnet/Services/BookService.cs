using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.DTOs;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services.IServices;

namespace libdb_dotnet.Services
{
    public class BookService : IBookService
    {
        private readonly IAuthorRepo _authorRepo;
        private readonly IBookRepo _bookRepo;

        public BookService(IAuthorRepo authorRepo, IBookRepo repo)
        {
            _authorRepo = authorRepo;
            _bookRepo = repo;
        }

        public async Task<Result<BookDTOFull>> CreateBook(BookRequestBody dto)
        {
            var book = await _bookRepo.FindOne(dto.Isbn);
            if (book != null)
            {
                return Result<BookDTOFull>.Fail("A book with the ISBN '" + dto.Isbn + "' already exists");
            }

            var author = await _authorRepo.FindOne(dto.AuthorId);
            if (author == null)
            {
                return Result<BookDTOFull>.Fail("No author with the ID '" + dto.AuthorId + "' was found");
            }

            var newBook = new Book
            {
                Isbn = dto.Isbn,
                Title = dto.Title,
                Author = author
            };

            newBook = await _bookRepo.Create(newBook);

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(newBook));
        }

        public async Task<Result<List<BookDTOFull>>> FindAllBooks(int pageNumber, int pageSize)
        {
            var bookList = pageNumber > 0 && pageSize > 0 ? await _bookRepo.FindAll(pageNumber, pageSize) : await _bookRepo.FindAll();
            if (bookList.Count == 0)
            {
                return Result<List<BookDTOFull>>.Fail("There are no books");
            }

            return Result<List<BookDTOFull>>.Success(bookList.ConvertAll(BookDTOFull.ToDTO));
        }

        public async Task<Result<List<BookDTOFull>>> FindBooks(string bookTitle)
        {
            var bookList = await _bookRepo.Find(bookTitle);
            if (bookList.Count == 0)
            {
                return Result<List<BookDTOFull>>.Fail("No books with a title containing '" + bookTitle + "' were found");
            }

            return Result<List<BookDTOFull>>.Success(bookList.ConvertAll(BookDTOFull.ToDTO));
        }

        public async Task<Result<BookDTOFull>> FindOneBook(string bookIsbn)
        {
            var book = await _bookRepo.FindOne(bookIsbn);
            if (book == null)
            {
                return Result<BookDTOFull>.Fail("No book with the ISBN '" + bookIsbn + "' was found");
            }

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }

        public async Task<Result<BookDTOFull>> UpdateBook(string bookIsbn, BookRequestBody dto)
        {
            var book = await _bookRepo.FindOne(bookIsbn);
            if (book == null)
            {
                return Result<BookDTOFull>.Fail("No book with the ISBN '" + bookIsbn + "' was found");
            }

            book.Title = dto.Title;

            await _bookRepo.CommitChanges();

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }

        public async Task<Result<BookDTOFull>> DeleteBook(string bookIsbn)
        {
            var book = await _bookRepo.FindOne(bookIsbn);
            if (book == null)
            {
                return Result<BookDTOFull>.Fail("No book with the ISBN '" + bookIsbn + "' was found");
            }

            await _bookRepo.Delete(book);

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }
    }
}