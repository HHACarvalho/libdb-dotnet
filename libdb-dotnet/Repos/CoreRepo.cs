using libdb_dotnet.Core;
using libdb_dotnet.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace libdb_dotnet.Repos
{
    public class CoreRepo<T> : ICoreRepo<T> where T : class
    {
        private readonly AppDBContext _dbc;
        protected readonly DbSet<T> _dbs;

        public CoreRepo(AppDBContext dbc, DbSet<T> dbs)
        {
            _dbc = dbc;
            _dbs = dbs;
        }

        public virtual async Task<T> Create(T entity)
        {
            var newEntity = await _dbs.AddAsync(entity);
            await CommitChanges();
            return newEntity.Entity;
        }

        public virtual async Task<List<T>> FindAll()
        {
            return await _dbs.ToListAsync();
        }

        public virtual async Task<List<T>> FindAll(int pageNumber, int pageSize)
        {
            return await _dbs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task Delete(T entity)
        {
            _dbs.Remove(entity);
            await CommitChanges();
        }

        public async Task CommitChanges()
        {
            await _dbc.SaveChangesAsync();
        }
    }
}