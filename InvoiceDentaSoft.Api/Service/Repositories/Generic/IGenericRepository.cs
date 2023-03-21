namespace InvoiceDentaSoft.Api.Service.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int? id);
        IEnumerable<T> GetAll();
        Task<T> Create(T entity);
    }
}
