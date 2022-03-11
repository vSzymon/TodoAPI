using TodoAPI.Domain.Interfaces;

namespace TodoAPI.Application.Interfaces
{
    public interface IGenericRepository<T> where T : IEntity
    {
        public T? FindById(Guid id);
        public Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
        public bool RemoveById(Guid id);
        public Task<bool> RemoveByIdAsync(Guid id, CancellationToken cancellationToken);
        public bool Add(T entity);
        public Task<bool> AddAsync(T entity, CancellationToken cancellationToken);
        public bool Update(T entity);
        public Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
