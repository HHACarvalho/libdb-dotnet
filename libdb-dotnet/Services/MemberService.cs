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

            return Result.Success(MemberDTO.Simple(newMember), 201);
        }

        public async Task<Result> FindAllMembers(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageNumber < 1)
            {
                pageNumber = 1;
                pageSize = 20;
            }

            var queryOutput = await _memberRepo.FindAll(pageNumber, pageSize);
            if (queryOutput.Array.Length == 0)
            {
                return Result.Fail("There are no members");
            }

            return Result.Success(new
            {
                totalCount = queryOutput.TotalCount,
                list = Array.ConvertAll(queryOutput.Array, MemberDTO.Simple)
            });
        }

        public async Task<Result> FindMembers(int pageNumber, int pageSize, int id, string? memberName, string? email, string? address, string? phoneNumber)
        {
            if (pageNumber < 1 || pageNumber < 1)
            {
                pageNumber = 1;
                pageSize = 20;
            }

            var queryOutput = await _memberRepo.Find(pageNumber, pageSize, id, memberName, email, address, phoneNumber);
            if (queryOutput.Array.Length == 0)
            {
                return Result.Fail("No members matching the criteria were found");
            }

            return Result.Success(new
            {
                totalCount = queryOutput.TotalCount,
                list = Array.ConvertAll(queryOutput.Array, MemberDTO.Simple)
            });
        }

        public async Task<Result> FindOneMember(int id)
        {
            var member = await _memberRepo.FindOne(id);
            if (member == null)
            {
                return Result.Fail("No member with the Id '" + id + "' was found");
            }

            return Result.Success(MemberDTO.Detailed(member));
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

            return Result.Success(null);
        }

        public async Task<Result> DeleteMember(int id)
        {
            var member = await _memberRepo.FindOne(id);
            if (member == null)
            {
                return Result.Fail("No member with the Id '" + id + "' was found");
            }

            await _memberRepo.Delete(member);

            return Result.Success(null);
        }
    }
}