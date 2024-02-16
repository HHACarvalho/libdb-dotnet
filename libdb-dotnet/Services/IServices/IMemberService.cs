using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IMemberService
    {
        Task<Result> CreateMember(MemberRequestBody requestBody);
        Task<Result> FindAllMembers(int pageNumber, int pageSize);
        Task<Result> FindMembers(string name);
        Task<Result> FindOneMember(int id);
        Task<Result> UpdateMember(int id, MemberRequestBody requestBody);
        Task<Result> DeleteMember(int id);
    }
}