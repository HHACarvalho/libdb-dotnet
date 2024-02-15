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

        public async Task<Result<BorrowDTOFull>> CreateBorrow(BorrowRequestBody requestBody)
        {
            var book = await _bookRepo.FindOne(requestBody.BookId);
            if (book == null)
            {
                return Result<BorrowDTOFull>.Fail("Book not found");
            }

            var member = await _memberRepo.FindOne(requestBody.MemberId);
            if (member == null)
            {
                return Result<BorrowDTOFull>.Fail("Member not found");
            }

            var newBorrow = new Borrow
            {
                Book = book,
                Member = member,
                BorrowDate = requestBody.BorrowDate,
                DueDate = requestBody.DueDate,
            };

            newBorrow = await _borrowRepo.Create(newBorrow);

            return Result<BorrowDTOFull>.Success(BorrowDTOFull.ToDTO(newBorrow));
        }

        public async Task<Result<List<BorrowDTOFull>>> FindAllBorrows(int pageNumber, int pageSize)
        {
            var borrowList = pageNumber > 0 && pageSize > 0 ? await _borrowRepo.FindAll(pageNumber, pageSize) : await _borrowRepo.FindAll();
            if (borrowList.Count == 0)
            {
                return Result<List<BorrowDTOFull>>.Fail("There are no borrows");
            }

            return Result<List<BorrowDTOFull>>.Success(borrowList.ConvertAll(BorrowDTOFull.ToDTO));
        }

        public async Task<Result<BorrowDTOFull>> FindOneBorrow(int id)
        {
            var borrow = await _borrowRepo.FindOne(id);
            if (borrow == null)
            {
                return Result<BorrowDTOFull>.Fail("No borrow with the Id '" + id + "' was found");
            }

            return Result<BorrowDTOFull>.Success(BorrowDTOFull.ToDTO(borrow));
        }

        public async Task<Result<BorrowDTOFull>> UpdateBorrow(int id, BorrowRequestBody requestBody)
        {
            var borrow = await _borrowRepo.FindOne(id);
            if (borrow == null)
            {
                return Result<BorrowDTOFull>.Fail("No borrow with the Id '" + id + "' was found");
            }

            borrow.ReturnDate = requestBody.ReturnDate;
            borrow.Fine = requestBody.Fine;

            await _borrowRepo.CommitChanges();

            return Result<BorrowDTOFull>.Success(BorrowDTOFull.ToDTO(borrow));
        }

        public async Task<Result<BorrowDTOFull>> DeleteBorrow(int id)
        {
            var borrow = await _borrowRepo.FindOne(id);
            if (borrow == null)
            {
                return Result<BorrowDTOFull>.Fail("No borrow with the Id '" + id + "' was found");
            }

            await _borrowRepo.Delete(borrow);

            return Result<BorrowDTOFull>.Success(BorrowDTOFull.ToDTO(borrow));
        }
    }
}