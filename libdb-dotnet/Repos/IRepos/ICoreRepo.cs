namespace libdb_dotnet.Repos.IRepos
{
    public interface ICoreRepo<TEntity>
    {
        Task Create(TEntity obj);
        Task<List<TEntity>> FindAll(int pageNumber = 1, int pageSize = 20);
        Task<TEntity?> FindOne(string id);
        Task Delete(TEntity obj);
        Task CommitChanges();
    }
}