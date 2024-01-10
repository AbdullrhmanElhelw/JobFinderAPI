namespace Application.DapperQueries.QueryBase;

public interface IQueryBase<T> where T : class
{
    Task<T?> Get(int Id);

    Task<IQueryable<T>> GetAll();
}