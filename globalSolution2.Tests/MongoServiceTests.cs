using globalSolution2.Services;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace globalSolution2.Tests
{
    public class MongoServiceTests
    {
        [Fact]
        public void Should_Insert_Data_To_MongoDB()
        {
            // Arrange
            var mockMongoClient = new Mock<IMongoClient>();
            var mockDatabase = new Mock<IMongoDatabase>();
            var mockCollection = new Mock<IMongoCollection<object>>();

            // Configuração do mock
            mockMongoClient
                .Setup(client => client.GetDatabase(It.IsAny<string>(), null))
                .Returns(mockDatabase.Object);

            mockDatabase
                .Setup(db => db.GetCollection<object>(It.IsAny<string>(), null))
                .Returns(mockCollection.Object);

            var service = new MongoService("mockConnectionString", "mockDatabase");

            // Act
            var collection = service.GetCollection<object>("mockCollection");

            // Assert
            Assert.NotNull(collection);
        }
    }
}
