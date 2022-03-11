using TodoAPI.Domain.Aggregates;

namespace TodoAPI.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public Task CommitAsync();
        IGenericRepository<TodoItem> TodoItemRepository { get; }
        IGenericRepository<TodoItemsList> TodoItemsListRepository { get;}

    }
}
