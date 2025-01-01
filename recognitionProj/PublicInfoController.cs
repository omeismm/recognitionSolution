using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicInfoController : ControllerBase
    {
        // In-memory list to store public information temporarily (for demonstration purposes)
        private readonly DatabaseHandler _dbHandler;
        public PublicInfoController(DatabaseHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }
        // POST: api/publicinfo/save
        [HttpPost("save")]
        public IActionResult SavePublicInfo([FromBody] PublicInfo publicInfo)
        {
            if (publicInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid public information data." });
            }

            _dbHandler.InsertPublicInfo(publicInfo);

            // Return success response
            return Ok(new { success = true, message = "Public information saved successfully." });
        }

        // GET: api/publicinfo/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllPublicInfo()
        {
            // Return all the public information (simulating retrieval from a database)
            return Ok();
        }
    }
}
