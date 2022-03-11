using StackExchange.Redis;
using TodoAPI.Application.Interfaces;
using TodoAPI.Domain.Aggregates;
using TodoAPI.Infrastructure.Redis;
using TodoAPI.Infrastructure.Repositories;

namespace TodoAPI.Infrastructure
{
    public class RootUnitOfWork : IUnitOfWork
    {
        public  IGenericRepository<TodoItem> TodoItemRepository { get; init; }
        public  IGenericRepository<TodoItemsList> TodoItemsListRepository { get; init; }

        private ITransaction transaction;
        public RootUnitOfWork(IRedisConnectionManager redisConnectionManager)
        {
            transaction = redisConnectionManager.Transaction;
            
            TodoItemRepository = new TodoItemRepository(transaction);
            TodoItemsListRepository = new TodoItemsListRepository(transaction);
        }
        public async Task CommitAsync()
        {
            await transaction.ExecuteAsync();
        }

        public void Dispose()
        {
        }
    }
}
