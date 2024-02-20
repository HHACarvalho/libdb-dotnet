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
                Author = author
            };

            newBook = await _bookRepo.Create(newBook);

            return Result.Success(BookDTO.Simple(newBook), 201);
        }

        public async Task<Result> FindAllBooks(int pageNumber, int pageSize)
        {
            var bookList = pageNumber > 0 && pageSize > 0 ? await _bookRepo.FindAll(pageNumber, pageSize) : await _bookRepo.FindAll();
            if (bookList.Count == 0)
            {
                return Result.Fail("There are no books");
            }

            return Result.Success(bookList.ConvertAll(BookDTO.Simple));
        }

        public async Task<Result> FindBooks(string title)
        {
            var bookList = await _bookRepo.Find(title);
            if (bookList.Count == 0)
            {
                return Result.Fail("No books with a title containing '" + title + "' were found");
            }

            return Result.Success(bookList.ConvertAll(BookDTO.Simple));
        }

        public async Task<Result> FindOneBook(int id)
        {
            var book = await _bookRepo.FindOne(id);
            if (book == null)
            {
                return Result.Fail("No book with the Id '" + id + "' was found");
            }

            return Result.Success(BookDTO.Simple(book));
        }

        public async Task<Result> UpdateBook(BookUpdateBody requestBody)
        {
            var book = await _bookRepo.FindOne(requestBody.Id);
            if (book == null)
            {
                return Result.Fail("No book with the Id '" + requestBody.Id + "' was found");
            }

            book.Title = requestBody.Title;

            await _bookRepo.CommitChanges();

            return Result.Success(BookDTO.Simple(book));
        }

        public async Task<Result> DeleteBook(int id)
        {
            var book = await _bookRepo.FindOne(id);
            if (book == null)
            {
                return Result.Fail("No book with the Id '" + id + "' was found");
            }

            await _bookRepo.Delete(book);

            return Result.Success(BookDTO.Simple(book));
        }
    }
}