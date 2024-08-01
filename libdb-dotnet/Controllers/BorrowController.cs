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
        public async Task<IActionResult> CreateBorrow(BorrowCreateBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.CreateBorrow(requestBody));
        }

        [HttpGet]
        public async Task<IActionResult> FindAllBorrows(int pageNumber, int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllBorrows(pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneBorrow(int id)
        {
            return await HandleServiceCall(async () => await _service.FindOneBorrow(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBorrow(BorrowUpdateBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.UpdateBorrow(requestBody));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrow(int id)
        {
            return await HandleServiceCall(async () => await _service.DeleteBorrow(id));
        }
    }
}