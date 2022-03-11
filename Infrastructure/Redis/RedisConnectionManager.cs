using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace TodoAPI.Infrastructure.Redis
{
    public class RedisConnectionManager : IRedisConnectionManager
    {
        private readonly ConnectionMultiplexer redis;
        public RedisConnectionManager(IOptions<ConfigurationOptions> configuration)
        {
            redis = ConnectionMultiplexer.Connect(configuration.Value);
        }

        public ITransaction Transaction => redis.GetDatabase().CreateTransaction();

        public async ValueTask DisposeAsync()
        {
            await redis?.CloseAsync();
            redis?.Dispose();
        }
    }

    public static class RedisConnectionManagerDI 
    {
        public static IServiceCollection AddRedisConnectionManager(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<ConfigurationOptions>(configuration.GetSection("RedisConnectionOptions"));
            services.AddSingleton<IRedisConnectionManager, RedisConnectionManager>();

            return services;    
        }
    }
}
