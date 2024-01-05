using libdb_dotnet.Core;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class CoreRepo<TEntity> : ICoreRepo<TEntity> where TEntity : Entity
    {
        private readonly AppDBContext _dbc;
        protected readonly DbSet<TEntity> _dbs;

        public CoreRepo(AppDBContext dbc, DbSet<TEntity> dbs)
        {
            _dbc = dbc;
            _dbs = dbs;
        }

        public virtual async Task Create(TEntity obj)
        {
            await _dbs.AddAsync(obj);
            await CommitChanges();
        }

        public virtual async Task<List<TEntity>> FindAll(int pageNumber = 1, int pageSize = 20)
        {
            return await _dbs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task<TEntity?> FindOne(string id)
        {
            return await _dbs.Where(x => x.ID.ToString().Equals(id)).FirstOrDefaultAsync();
        }

        public virtual async Task Delete(TEntity obj)
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