using libdb_dotnet.Core;
using libdb_dotnet.DTOs;

namespace libdb_dotnet.Services.IServices
{
    public interface IMemberService
    {
        Task<Result<MemberDTOFull>> CreateMember(MemberRequestBody requestBody);
        Task<Result<List<MemberDTOFull>>> FindAllMembers(int pageNumber, int pageSize);
        Task<Result<List<MemberDTOFull>>> FindMembers(string name);
        Task<Result<MemberDTOFull>> FindOneMember(int id);
        Task<Result<MemberDTOFull>> UpdateMember(int id, MemberRequestBody requestBody);
        Task<Result<MemberDTOFull>> DeleteMember(int id);
    }
}