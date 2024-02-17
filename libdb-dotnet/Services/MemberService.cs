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

        public async Task<Result> CreateMember(MemberCreateBody requestBody)
        {
            var newMember = new Member
            {
                Name = requestBody.Name,
                Email = requestBody.Email,
                Address = requestBody.Address,
                PhoneNumber = requestBody.PhoneNumber
            };

            newMember = await _memberRepo.Create(newMember);

            return Result.Success(MemberDTO.Simple(newMember));
        }

        public async Task<Result> FindAllMembers(int pageNumber, int pageSize)
        {
            var memberList = pageNumber > 0 && pageSize > 0 ? await _memberRepo.FindAll(pageNumber, pageSize) : await _memberRepo.FindAll();
            if (memberList.Count == 0)
            {
                return Result.Fail("There are no members");
            }

            return Result.Success(memberList.ConvertAll(MemberDTO.Simple));
        }

        public async Task<Result> FindMembers(string name)
        {
            var memberList = await _memberRepo.Find(name);
            if (memberList.Count == 0)
            {
                return Result.Fail("No members with a name containing '" + name + "' were found");
            }

            return Result.Success(memberList.ConvertAll(MemberDTO.Simple));
        }

        public async Task<Result> FindOneMember(int id)
        {
            var member = await _memberRepo.FindOne(id);
            if (member == null)
            {
                return Result.Fail("No member with the Id '" + id + "' was found");
            }

            return Result.Success(MemberDTO.Simple(member));
        }

        public async Task<Result> UpdateMember(MemberUpdateBody requestBody)
        {
            var member = await _memberRepo.FindOne(requestBody.Id);
            if (member == null)
            {
                return Result.Fail("No member with the Id '" + requestBody.Id + "' was found");
            }

            member.Name = requestBody.Name;
            member.Email = requestBody.Email;
            member.Address = requestBody.Address;
            member.PhoneNumber = requestBody.PhoneNumber;

            await _memberRepo.CommitChanges();

            return Result.Success(MemberDTO.Simple(member));
        }

        public async Task<Result> DeleteMember(int id)
        {
            var member = await _memberRepo.FindOne(id);
            if (member == null)
            {
                return Result.Fail("No member with the Id '" + id + "' was found");
            }

            await _memberRepo.Delete(member);

            return Result.Success(MemberDTO.Simple(member));
        }
    }
}