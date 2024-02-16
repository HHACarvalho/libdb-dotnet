using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IBorrowService
    {
        Task<Result> CreateBorrow(BorrowRequestBody requestBody);
        Task<Result> FindAllBorrows(int pageNumber, int pageSize);
        Task<Result> FindOneBorrow(int id);
        Task<Result> UpdateBorrow(int id, BorrowRequestBody requestBody);
        Task<Result> DeleteBorrow(int id);
    }
}