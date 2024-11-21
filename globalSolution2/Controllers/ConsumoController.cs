using Microsoft.AspNetCore.Mvc;
using globalSolution2.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace globalSolution2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumoController : ControllerBase
    {
        private readonly MongoService _mongoService;

        public ConsumoController(MongoService mongoService)
        {
            _mongoService = mongoService;
        }

        [HttpGet]
        public IActionResult GetConsumo()
        {
            try
            {
                var collection = _mongoService.GetCollection<BsonDocument>("consumo");
                var result = collection.Find(new BsonDocument()).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult RegisterConsumo([FromBody] BsonDocument consumo)
        {
            try
            {
                if (consumo == null)
                {
                    return BadRequest(new { message = "Consumo inválido." });
                }

                var collection = _mongoService.GetCollection<BsonDocument>("consumo");
                collection.InsertOne(consumo);

                return Created("", new { message = "Consumo registrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
