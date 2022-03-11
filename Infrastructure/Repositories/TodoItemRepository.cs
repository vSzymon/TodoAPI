using StackExchange.Redis;
using TodoAPI.Application.Interfaces;
using TodoAPI.Domain.Aggregates;

namespace TodoAPI.Infrastructure.Repositories
{
    public class TodoItemRepository : IGenericRepository<TodoItem>
    {
        private static List<TodoItem> todos = new(10);

        private readonly ITransaction transaction;

        public TodoItemRepository(ITransaction transaction)
        {
            this.transaction = transaction;
        }
        public bool Add(TodoItem entity)
        {
            todos.Add(entity);
            return true;
        }

        public Task<bool> AddAsync(TodoItem entity, CancellationToken cancellationToken)
        {
            entity.Id = Guid.NewGuid();
            todos.Add(entity);
            return Task.FromResult(true);
        }

        public TodoItem FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool Update(TodoItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TodoItem entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
