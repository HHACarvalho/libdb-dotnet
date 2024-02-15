using libdb_dotnet.DTOs;
using libdb_dotnet.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace libdb_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowController(IBorrowService service) : CoreController
    {
        private readonly IBorrowService _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateBorrow(BorrowRequestBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.CreateBorrow(requestBody));
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllBorrows(int pageNumber, int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllBorrows(pageNumber, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> FindOneBorrow(int id)
        {
            return await HandleServiceCall(async () => await _service.FindOneBorrow(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBorrow(int id, BorrowRequestBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.UpdateBorrow(id, requestBody));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBorrow(int id)
        {
            return await HandleServiceCall(async () => await _service.DeleteBorrow(id));
        }
    }
}