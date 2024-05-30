using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class MemberRepo : CoreRepo<Member>, IMemberRepo
    {
        public MemberRepo(AppDBContext dbc) : base(dbc, dbc.Members) { }

        public async Task<QueryOutput<Member>> FindAll(int pageNumber, int pageSize)
        {
            var output = new QueryOutput<Member>(
                await _dbs.CountAsync(),
                await _dbs
                    .OrderByDescending(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync()
            );

            return output;
        }

        public async Task<QueryOutput<Member>> Find(int pageNumber, int pageSize, int id, string? name, string? email, string? address, string? phoneNumber)
        {
            IQueryable<Member> subSet = _dbs;

            if (id > 0)
            {
                subSet = subSet.Where(x => x.Id.Equals(id));
            }

            if (!string.IsNullOrEmpty(name))
            {
                subSet = subSet.Where(x => x.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                subSet = subSet.Where(x => x.Email.Contains(email));
            }

            if (!string.IsNullOrEmpty(address))
            {
                subSet = subSet.Where(x => x.Address.Contains(address));
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                subSet = subSet.Where(x => x.PhoneNumber.Contains(phoneNumber));
            }

            var output = new QueryOutput<Member>(
                await subSet.CountAsync(),
                await subSet
                    .OrderByDescending(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToArrayAsync()
            );

            return output;
        }

        public async Task<Member?> FindOne(int id)
        {
            return await _dbs
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Borrows)
                .ThenInclude(x => x.BookEntry)
                .ThenInclude(x => x.Book)
                .FirstOrDefaultAsync();
        }
    }
}