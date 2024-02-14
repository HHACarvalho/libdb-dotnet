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

        public async Task<Result<BookDTOFull>> CreateBook(BookRequestBody requestBody)
        {
            var author = await _authorRepo.FindOne(requestBody.AuthorId);
            if (author == null)
            {
                return Result<BookDTOFull>.Fail("Author not found");
            }

            var newBook = new Book
            {
                Title = requestBody.Title,
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

        public async Task<Result<List<BookDTOFull>>> FindBooks(string title)
        {
            var bookList = await _bookRepo.Find(title);
            if (bookList.Count == 0)
            {
                return Result<List<BookDTOFull>>.Fail("No books with a title containing '" + title + "' were found");
            }

            return Result<List<BookDTOFull>>.Success(bookList.ConvertAll(BookDTOFull.ToDTO));
        }

        public async Task<Result<BookDTOFull>> FindOneBook(int id)
        {
            var book = await _bookRepo.FindOne(id);
            if (book == null)
            {
                return Result<BookDTOFull>.Fail("No book with the Id '" + id + "' was found");
            }

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }

        public async Task<Result<BookDTOFull>> UpdateBook(int id, BookRequestBody requestBody)
        {
            var book = await _bookRepo.FindOne(id);
            if (book == null)
            {
                return Result<BookDTOFull>.Fail("No book with the Id '" + id + "' was found");
            }

            book.Title = requestBody.Title;

            await _bookRepo.CommitChanges();

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }

        public async Task<Result<BookDTOFull>> DeleteBook(int id)
        {
            var book = await _bookRepo.FindOne(id);
            if (book == null)
            {
                return Result<BookDTOFull>.Fail("No book with the Id '" + id + "' was found");
            }

            await _bookRepo.Delete(book);

            return Result<BookDTOFull>.Success(BookDTOFull.ToDTO(book));
        }
    }
}