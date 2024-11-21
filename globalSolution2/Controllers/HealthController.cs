using Microsoft.AspNetCore.Mvc;
using globalSolution2.Services;

namespace globalSolution2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly MongoService _mongoService;

        public HealthController(MongoService mongoService)
        {
            _mongoService = mongoService;
        }

        [HttpGet("health")]
        public IActionResult CheckHealth()
        {
            return Ok(new { status = "Healthy" });
        }

        [HttpGet("mongo-test")]
        public IActionResult TestMongo()
        {
            try
            {
                var collection = _mongoService.GetCollection<object>("consumo");
                return Ok(new { status = "Conectado ao MongoDB com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
