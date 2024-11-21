using globalSolution2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace globalSolution2.Tests
{
    public class ConsumoControllerTests
    {
        [Fact]
        public void ConsumoPost_Should_Return_500_On_Error()
        {
           
            var controller = new ConsumoController();


            object? mockConsumo = null;

            
            IActionResult result = controller.RegisterConsumo(mockConsumo);

           
            var errorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, errorResult.StatusCode);
        }
    }
}
