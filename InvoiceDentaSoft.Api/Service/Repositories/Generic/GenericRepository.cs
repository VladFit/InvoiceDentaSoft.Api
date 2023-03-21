using InvoiceDentaSoft.Api.Context;

namespace InvoiceDentaSoft.Api.Service.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await Task.FromResult(entity);
        }


        public async Task<T> GetByIdAsync(int? id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
