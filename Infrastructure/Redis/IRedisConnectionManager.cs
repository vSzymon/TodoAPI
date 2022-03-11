using StackExchange.Redis;

namespace TodoAPI.Infrastructure.Redis
{
    public interface IRedisConnectionManager : IAsyncDisposable
    {
        public ITransaction Transaction { get; }
    }
}