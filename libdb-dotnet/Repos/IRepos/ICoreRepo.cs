namespace libdb_dotnet.Repos.IRepos
{
    public interface ICoreRepo<T>
    {
        Task<T> Create(T entity);
        Task Delete(T entity);
        Task CommitChanges();
    }
}