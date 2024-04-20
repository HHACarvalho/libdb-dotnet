using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.DTOs;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services.IServices;

namespace libdb_dotnet.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBookEntryRepo _bookEntryRepo;
        private readonly IBorrowRepo _borrowRepo;
        private readonly IMemberRepo _memberRepo;

        public BorrowService(IBookEntryRepo bookEntryRepo, IBorrowRepo borrowRepo, IMemberRepo memberRepo)
        {
            _bookEntryRepo = bookEntryRepo;
            _borrowRepo = borrowRepo;
            _memberRepo = memberRepo;
        }

        public async Task<Result> CreateBorrow(BorrowCreateBody requestBody)
        {
            var bookEntry = await _bookEntryRepo.FindOne(requestBody.BookEntryId);
            if (bookEntry == null)
            {
                return Result.Fail("Book not found", 400);
            }

            var member = await _memberRepo.FindOne(requestBody.MemberId);
            if (member == null)
            {
                return Result.Fail("Member not found", 400);
            }

            var newBorrow = new Borrow
            {
                BookEntry = bookEntry,
                Member = member,
                BorrowDate = DateOnly.ParseExact(requestBody.BorrowDate, "dd-MM-yyyy"),
                DueDate = DateOnly.ParseExact(requestBody.DueDate, "dd-MM-yyyy"),
            };

            newBorrow = await _borrowRepo.Create(newBorrow);

            return Result.Success(BorrowDTO.Simple(newBorrow), 201);
        }

        public async Task<Result> FindAllBorrows(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageNumber < 1)
            {
                pageNumber = 1;
                pageSize = 20;
            }

            var queryOutput = await _borrowRepo.FindAll(pageNumber, pageSize);
            if (queryOutput.Array.Length == 0)
            {
                return Result.Fail("There are no borrows");
            }

            return Result.Success(new
            {
                total = queryOutput.TotalCount,
                array = Array.ConvertAll(queryOutput.Array, BorrowDTO.Simple)
            });
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

            return Result.Success(null);
        }

        public async Task<Result> DeleteBorrow(int id)
        {
            var borrow = await _borrowRepo.FindOne(id);
            if (borrow == null)
            {
                return Result.Fail("No borrow with the Id '" + id + "' was found");
            }

            await _borrowRepo.Delete(borrow);

            return Result.Success(null);
        }
    }
}