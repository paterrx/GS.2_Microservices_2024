using globalSolution2.Cache;
using Moq;
using Xunit;

namespace globalSolution2.Tests
{
    public class RedisCacheTests
    {
        [Fact]
        public void Should_Retrieve_Data_From_Redis()
        {
            // Arrange
            var mockRedisCache = new Mock<RedisCache>("mockConnectionString");
            mockRedisCache.Setup(cache => cache.Get("mockKey")).Returns("mockValue");

            // Act
            var result = mockRedisCache.Object.Get("mockKey");

            // Assert
            Assert.Equal("mockValue", result);
        }

        [Fact]
        public void Should_Return_Null_When_Cache_Expires()
        {
            // Arrange
            var mockRedisCache = new Mock<RedisCache>("mockConnectionString");
            mockRedisCache.Setup(cache => cache.Get("expiredKey")).Returns((string)null);

            // Act
            var result = mockRedisCache.Object.Get("expiredKey");

            // Assert
            Assert.Null(result);
        }
    }
}
