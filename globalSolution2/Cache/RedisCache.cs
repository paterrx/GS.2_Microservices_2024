using StackExchange.Redis;

namespace globalSolution2.Cache
{
    public class RedisCache
    {
        private readonly ConnectionMultiplexer _redis;

        public RedisCache(string connectionString)
        {
            _redis = ConnectionMultiplexer.Connect(connectionString);
        }

        public string? Get(string key)
        {
            var db = _redis.GetDatabase();
            return db.StringGet(key);
        }

        public void Set(string key, string value, TimeSpan expiration)
        {
            var db = _redis.GetDatabase();
            db.StringSet(key, value, expiration);
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                var db = _redis.GetDatabase();
                await db.PingAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
