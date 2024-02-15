using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.DTOs;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services.IServices;

namespace libdb_dotnet.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepo _memberRepo;

        public MemberService(IMemberRepo memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<Result<MemberDTOFull>> CreateMember(MemberRequestBody requestBody)
        {
            var newMember = new Member
            {
                Name = requestBody.Name,
                Email = requestBody.Email,
                Address = requestBody.Address,
                PhoneNumber = requestBody.PhoneNumber
            };

            newMember = await _memberRepo.Create(newMember);

            return Result<MemberDTOFull>.Success(MemberDTOFull.ToDTO(newMember));
        }

        public async Task<Result<List<MemberDTOFull>>> FindAllMembers(int pageNumber, int pageSize)
        {
            var memberList = pageNumber > 0 && pageSize > 0 ? await _memberRepo.FindAll(pageNumber, pageSize) : await _memberRepo.FindAll();
            if (memberList.Count == 0)
            {
                return Result<List<MemberDTOFull>>.Fail("There are no members");
            }

            return Result<List<MemberDTOFull>>.Success(memberList.ConvertAll(MemberDTOFull.ToDTO));
        }

        public async Task<Result<List<MemberDTOFull>>> FindMembers(string name)
        {
            var memberList = await _memberRepo.Find(name);
            if (memberList.Count == 0)
            {
                return Result<List<MemberDTOFull>>.Fail("No members with a name containing '" + name + "' were found");
            }

            return Result<List<MemberDTOFull>>.Success(memberList.ConvertAll(MemberDTOFull.ToDTO));
        }

        public async Task<Result<MemberDTOFull>> FindOneMember(int id)
        {
            var member = await _memberRepo.FindOne(id);
            if (member == null)
            {
                return Result<MemberDTOFull>.Fail("No member with the Id '" + id + "' was found");
            }

            return Result<MemberDTOFull>.Success(MemberDTOFull.ToDTO(member));
        }

        public async Task<Result<MemberDTOFull>> UpdateMember(int id, MemberRequestBody requestBody)
        {
            var member = await _memberRepo.FindOne(id);
            if (member == null)
            {
                return Result<MemberDTOFull>.Fail("No member with the Id '" + id + "' was found");
            }

            member.Name = requestBody.Name;
            member.Email = requestBody.Email;
            member.Address = requestBody.Address;
            member.PhoneNumber = requestBody.PhoneNumber;

            await _memberRepo.CommitChanges();

            return Result<MemberDTOFull>.Success(MemberDTOFull.ToDTO(member));
        }

        public async Task<Result<MemberDTOFull>> DeleteMember(int id)
        {
            var member = await _memberRepo.FindOne(id);
            if (member == null)
            {
                return Result<MemberDTOFull>.Fail("No member with the Id '" + id + "' was found");
            }

            await _memberRepo.Delete(member);

            return Result<MemberDTOFull>.Success(MemberDTOFull.ToDTO(member));
        }
    }
}