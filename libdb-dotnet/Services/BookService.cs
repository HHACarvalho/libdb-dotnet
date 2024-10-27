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

        public async Task<Result> CreateBook(BookCreateBody requestBody)
        {
            var author = await _authorRepo.FindOne(requestBody.AuthorId);
            if (author == null)
            {
                return Result.Fail("Author not found", 400);
            }

            var newBook = new Book
            {
                Title = requestBody.Title,
                Year = requestBody.Year,
                Genre = requestBody.Genre,
                ImageUrl = requestBody.ImageUrl,
                Author = author,
                BookEntries = new List<BookEntry>()
            };

            newBook = await _bookRepo.Create(newBook);

            return Result.Success(BookDTO.Simple(newBook), 201);
        }

        public async Task<Result> FindAllBooks(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 16;

            var queryOutput = await _bookRepo.FindAll(pageNumber, pageSize);
            if (queryOutput.Array.Length == 0)
            {
                return Result.Fail("There are no books");
            }

            return Result.Success(new
            {
                total = queryOutput.TotalCount,
                array = Array.ConvertAll(queryOutput.Array, BookDTO.Simple)
            });
        }

        public async Task<Result> FindBooks(int pageNumber, int pageSize, int id, string? title, int year, string? genre, string? authorName)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 16;

            var queryOutput = await _bookRepo.Find(pageNumber, pageSize, id, title, year, genre, authorName);
            if (queryOutput.Array.Length == 0)
            {
                return Result.Fail("No books matching the criteria were found");
            }

            return Result.Success(new
            {
                total = queryOutput.TotalCount,
                array = Array.ConvertAll(queryOutput.Array, BookDTO.Simple)
            });
        }

        public async Task<Result> FindOneBook(int id)
        {
            var book = await _bookRepo.FindOne(id);
            if (book == null)
            {
                return Result.Fail("No book with the Id '" + id + "' was found");
            }

            return Result.Success(BookDTO.Detailed(book));
        }

        public async Task<Result> UpdateBook(BookUpdateBody requestBody)
        {
            var book = await _bookRepo.FindOne(requestBody.Id);
            if (book == null)
            {
                return Result.Fail("No book with the Id '" + requestBody.Id + "' was found");
            }

            book.Title = requestBody.Title;
            book.Year = requestBody.Year;
            book.Genre = requestBody.Genre;
            book.ImageUrl = requestBody.ImageUrl;

            await _bookRepo.CommitChanges();

            return Result.Success(null);
        }

        public async Task<Result> DeleteBook(int id)
        {
            var book = await _bookRepo.FindOne(id);
            if (book == null)
            {
                return Result.Fail("No book with the Id '" + id + "' was found");
            }

            await _bookRepo.Delete(book);

            return Result.Success(null);
        }
    }
}