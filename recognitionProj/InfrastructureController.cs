using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfrastructureController : ControllerBase
    {
        // In-memory list to store infrastructure information temporarily (for demonstration purposes)
        private static List<Infrastructure> _infrastructureInfoList = new List<Infrastructure>();

        // POST: api/infrastructure/save
        [HttpPost("save")]
        public IActionResult SaveInfrastructureInfo([FromBody] Infrastructure infrastructureInfo)
        {
            if (infrastructureInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid infrastructure information data." });
            }

            // Add the infrastructure information object to the list (simulating saving to a database)
            _infrastructureInfoList.Add(infrastructureInfo);

            // Return success response
            return Ok(new { success = true, message = "Infrastructure information saved successfully." });
        }

        // GET: api/infrastructure/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllInfrastructureInfo()
        {
            // Return all the infrastructure information (simulating retrieval from a database)
            return Ok(_infrastructureInfoList);
        }
    }
}
