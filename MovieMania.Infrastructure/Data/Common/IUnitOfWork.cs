namespace MovieMania.Infrastructure.Data.Common
{
    public interface IUnitOfWork
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();
    }
}
