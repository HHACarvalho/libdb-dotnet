using libdb_dotnet.DTOs;
using libdb_dotnet.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace libdb_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController(IAuthorService service) : CoreController
    {
        private readonly IAuthorService _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorCreateBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.CreateAuthor(requestBody));
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllAuthors(int pageNumber, int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllAuthors(pageNumber, pageSize));
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindAuthors(int pageNumber, int pageSize, int id = 0, string? name = null)
        {
            return await HandleServiceCall(async () => await _service.FindAuthors(pageNumber, pageSize, id, name));
        }

        [HttpGet]
        public async Task<IActionResult> FindOneAuthor(int id)
        {
            return await HandleServiceCall(async () => await _service.FindOneAuthor(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(AuthorUpdateBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.UpdateAuthor(requestBody));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            return await HandleServiceCall(async () => await _service.DeleteAuthor(id));
        }
    }
}