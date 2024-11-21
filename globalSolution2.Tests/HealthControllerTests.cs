using globalSolution2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace globalSolution2.Tests
{
    public class HealthControllerTests
    {
        [Fact]
        public void HealthCheck_Should_Return_Status_200()
        {
           
            var controller = new HealthController();

            var result = controller.CheckHealth();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
