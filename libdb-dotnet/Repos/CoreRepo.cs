using libdb_dotnet.Core;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class CoreRepo<TDomain> : ICoreRepo<TDomain> where TDomain : class
    {
        private readonly AppDBContext _dbc;
        protected readonly DbSet<TDomain> _dbs;

        public CoreRepo(AppDBContext dbc, DbSet<TDomain> dbs)
        {
            _dbc = dbc;
            _dbs = dbs;
        }

        public virtual async Task Create(TDomain obj)
        {
            await _dbs.AddAsync(obj);
            await CommitChanges();
        }

        public virtual async Task<List<TDomain>> FindAll(int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task Delete(TDomain obj)
        {
            _dbs.Remove(obj);
            await CommitChanges();
        }

        public async Task CommitChanges()
        {
            await _dbc.SaveChangesAsync();
        }
    }
}