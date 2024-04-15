using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IMemberService
    {
        Task<Result> CreateMember(MemberCreateBody requestBody);
        Task<Result> FindAllMembers(int pageNumber, int pageSize);
        Task<Result> FindMembers(int pageNumber, int pageSize, int id, string? memberName, string? email, string? address, string? phoneNumber);
        Task<Result> FindOneMember(int id);
        Task<Result> UpdateMember(MemberUpdateBody requestBody);
        Task<Result> DeleteMember(int id);
    }
}