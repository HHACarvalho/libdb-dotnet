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
        public async Task<IActionResult> CreateAuthor(AuthorRequestBody dto)
        {
            return await HandleServiceCall(async () => await _service.CreateAuthor(dto));
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllAuthors(int pageNumber, int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllAuthors(pageNumber, pageSize));
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindAuthors(string authorName)
        {
            return await HandleServiceCall(async () => await _service.FindAuthors(authorName));
        }

        [HttpGet]
        public async Task<IActionResult> FindOneAuthor(string authorID)
        {
            return await HandleServiceCall(async () => await _service.FindOneAuthor(authorID));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(string authorID, AuthorRequestBody dto)
        {
            return await HandleServiceCall(async () => await _service.UpdateAuthor(authorID, dto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(string authorID)
        {
            return await HandleServiceCall(async () => await _service.DeleteAuthor(authorID));
        }
    }
}