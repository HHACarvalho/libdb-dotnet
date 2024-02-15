using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBorrowService
    {
        Task<Result<BorrowDTOFull>> CreateBorrow(BorrowRequestBody requestBody);
        Task<Result<List<BorrowDTOFull>>> FindAllBorrows(int pageNumber, int pageSize);
        Task<Result<BorrowDTOFull>> FindOneBorrow(int id);
        Task<Result<BorrowDTOFull>> UpdateBorrow(int id, BorrowRequestBody requestBody);
        Task<Result<BorrowDTOFull>> DeleteBorrow(int id);
    }
}