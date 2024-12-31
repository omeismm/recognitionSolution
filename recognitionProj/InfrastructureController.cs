using Microsoft.AspNetCore.Mvc;
using recognitionProj;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfrastructureController : ControllerBase
    {
        private readonly DatabaseHandler _dbHandler;

        // Constructor injection for DatabaseHandler
        public InfrastructureController(DatabaseHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        // POST: api/infrastructure/save
        [HttpPost("save")]
        public IActionResult SaveInfrastructureInfo([FromBody] Infrastructure infrastructureInfo)
        {
            if (infrastructureInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid infrastructure information data." });
            }

            // Instead of calling itself, call DatabaseHandler
            _dbHandler.InsertInfrastructure(infrastructureInfo);
            // or if you want to update, use: _dbHandler.UpdateInfrastructure(infrastructureInfo);

            return Ok(new { success = true, message = "Infrastructure information saved successfully." });
        }

        // GET: api/infrastructure/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllInfrastructureInfo()
        {
            // If you want to retrieve from DB, do something like:
            // var allInfrastructure = _dbHandler.GetAllInfrastructure();
            // return Ok(allInfrastructure);

            return Ok(new { success = true, message = "Implement retrieval if needed." });
        }
    }
}
