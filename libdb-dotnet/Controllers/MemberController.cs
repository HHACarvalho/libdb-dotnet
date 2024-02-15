using libdb_dotnet.DTOs;
using libdb_dotnet.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace libdb_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController(IMemberService service) : CoreController
    {
        private readonly IMemberService _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberRequestBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.CreateMember(requestBody));
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllMembers(int pageNumber, int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllMembers(pageNumber, pageSize));
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindMembers(string name)
        {
            return await HandleServiceCall(async () => await _service.FindMembers(name));
        }

        [HttpGet]
        public async Task<IActionResult> FindOneMember(int id)
        {
            return await HandleServiceCall(async () => await _service.FindOneMember(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMember(int id, MemberRequestBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.UpdateMember(id, requestBody));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMember(int id)
        {
            return await HandleServiceCall(async () => await _service.DeleteMember(id));
        }
    }
}