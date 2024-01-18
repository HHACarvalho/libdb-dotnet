using libdb_dotnet.Core;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class CoreRepo<TEntity> : ICoreRepo<TEntity> where TEntity : class
    {
        private readonly AppDBContext _dbc;
        protected readonly DbSet<TEntity> _dbs;

        public CoreRepo(AppDBContext dbc, DbSet<TEntity> dbs)
        {
            _dbc = dbc;
            _dbs = dbs;
        }

        public async Task<TEntity> Create(TEntity obj)
        {
            var newEntity = await _dbs.AddAsync(obj);
            await CommitChanges();
            return newEntity.Entity;
        }

        public async Task<List<TEntity>> FindAll(int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task Delete(TEntity obj)
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