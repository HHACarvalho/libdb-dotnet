using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.DTOs;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services.IServices;

namespace libdb_dotnet.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBookRepo _bookRepo;
        private readonly IBorrowRepo _borrowRepo;
        private readonly IMemberRepo _memberRepo;

        public BorrowService(IBookRepo bookRepo, IBorrowRepo repo, IMemberRepo memberRepo)
        {
            _bookRepo = bookRepo;
            _borrowRepo = repo;
            _memberRepo = memberRepo;
        }

        public async Task<Result> CreateBorrow(BorrowCreateBody requestBody)
        {
            var book = await _bookRepo.FindOne(requestBody.BookId);
            if (book == null)
            {
                return Result.Fail("Book not found");
            }

            var member = await _memberRepo.FindOne(requestBody.MemberId);
            if (member == null)
            {
                return Result.Fail("Member not found");
            }

            var newBorrow = new Borrow
            {
                Book = book,
                Member = member,
                BorrowDate = DateOnly.ParseExact(requestBody.BorrowDate, "dd-MM-yyyy"),
                DueDate = DateOnly.ParseExact(requestBody.DueDate, "dd-MM-yyyy"),
            };

            newBorrow = await _borrowRepo.Create(newBorrow);

            return Result.Success(BorrowDTO.Simple(newBorrow));
        }

        public async Task<Result> FindAllBorrows(int pageNumber, int pageSize)
        {
            var borrowList = pageNumber > 0 && pageSize > 0 ? await _borrowRepo.FindAll(pageNumber, pageSize) : await _borrowRepo.FindAll();
            if (borrowList.Count == 0)
            {
                return Result.Fail("There are no borrows");
            }

            return Result.Success(borrowList.ConvertAll(BorrowDTO.Simple));
        }

        public async Task<Result> FindOneBorrow(int id)
        {
            var borrow = await _borrowRepo.FindOne(id);
            if (borrow == null)
            {
                return Result.Fail("No borrow with the Id '" + id + "' was found");
            }

            return Result.Success(BorrowDTO.Simple(borrow));
        }

        public async Task<Result> UpdateBorrow(BorrowUpdateBody requestBody)
        {
            var borrow = await _borrowRepo.FindOne(requestBody.Id);
            if (borrow == null)
            {
                return Result.Fail("No borrow with the Id '" + requestBody.Id + "' was found");
            }

            borrow.ReturnDate = DateOnly.ParseExact(requestBody.ReturnDate, "dd-MM-yyyy");
            borrow.Fine = requestBody.Fine;

            await _borrowRepo.CommitChanges();

            return Result.Success(BorrowDTO.Simple(borrow));
        }

        public async Task<Result> DeleteBorrow(int id)
        {
            var borrow = await _borrowRepo.FindOne(id);
            if (borrow == null)
            {
                return Result.Fail("No borrow with the Id '" + id + "' was found");
            }

            await _borrowRepo.Delete(borrow);

            return Result.Success(BorrowDTO.Simple(borrow));
        }
    }
}