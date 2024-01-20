namespace libdb_dotnet.Repos.IRepos
{
    public interface ICoreRepo<T>
    {
        Task<T> Create(T entity);
        Task<List<T>> FindAll(int pageNumber = 1, int pageSize = 20);
        Task Delete(T entity);
        Task CommitChanges();
    }
}