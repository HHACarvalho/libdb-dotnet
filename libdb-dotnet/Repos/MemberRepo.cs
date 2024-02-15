using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class MemberRepo : CoreRepo<Member>, IMemberRepo
    {
        public MemberRepo(AppDBContext dbc) : base(dbc, dbc.Members) { }

        public async Task<List<Member>> Find(string name)
        {
            return await _dbs.Where(x => x.Name.Equals(name)).ToListAsync();
        }

        public async Task<Member?> FindOne(int id)
        {
            return await _dbs.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}