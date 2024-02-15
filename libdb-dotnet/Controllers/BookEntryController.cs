using libdb_dotnet.DTOs;
using libdb_dotnet.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace libdb_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookEntryController(IBookEntryService service) : CoreController
    {
        private readonly IBookEntryService _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateBookEntry(BookEntryRequestBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.CreateBookEntry(requestBody));
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllBookEntrys(int pageNumber, int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllBookEntries(pageNumber, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> FindOneBookEntry(int id)
        {
            return await HandleServiceCall(async () => await _service.FindOneBookEntry(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookEntry(int id, BookEntryRequestBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.UpdateBookEntry(id, requestBody));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookEntry(int id)
        {
            return await HandleServiceCall(async () => await _service.DeleteBookEntry(id));
        }
    }
}