using StackExchange.Redis;
using TodoAPI.Application.Interfaces;
using TodoAPI.Domain.Aggregates;

namespace TodoAPI.Infrastructure.Repositories
{
    public class TodoItemsListRepository : IGenericRepository<TodoItemsList>
    {
        private static List<TodoItemsList> todoItemsLists = new List<TodoItemsList>(10);
        private readonly ITransaction transaction;

        public TodoItemsListRepository(ITransaction transaction)
        {
            this.transaction = transaction;
        }
        public bool Add(TodoItemsList entity)
        {
            entity.Id = Guid.NewGuid();
            todoItemsLists.Add(entity); 
            return true;
        }

        public async Task<bool> AddAsync(TodoItemsList entity, CancellationToken cancellationToken)
        {
            await transaction.HashGetAsync("", "");
            entity.Id = Guid.NewGuid();
            todoItemsLists.Add(entity);
            return await Task.FromResult(true);
        }

        public TodoItemsList? FindById(Guid id)
        {
            return todoItemsLists.FirstOrDefault(t => t.Id == id);
        }

        public Task<TodoItemsList?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Task.FromResult(todoItemsLists.FirstOrDefault(t => t.Id == id));
        }

        public bool RemoveById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool Update(TodoItemsList entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TodoItemsList entity, CancellationToken cancellationToken)
        {
            var index = todoItemsLists.IndexOf(todoItemsLists.FirstOrDefault(e => e.Id == entity.Id)!);
            todoItemsLists[index] = entity; 
            return Task.FromResult(true);
        }
    }
}
