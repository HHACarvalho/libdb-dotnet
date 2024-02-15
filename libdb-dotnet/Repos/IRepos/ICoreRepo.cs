namespace libdb_dotnet.Repos.IRepos
{
    public interface ICoreRepo<T>
    {
        Task<T> Create(T entity);
        Task<List<T>> FindAll();
        Task<List<T>> FindAll(int pageNumber, int pageSize);
        Task Delete(T entity);
        Task CommitChanges();
    }
}