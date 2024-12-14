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
        private static List<PublicInfo> _publicInfoList = new List<PublicInfo>();

        // POST: api/publicinfo/save
        [HttpPost("save")]
        public IActionResult SavePublicInfo([FromBody] PublicInfo publicInfo)
        {
            if (publicInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid public information data." });
            }

            // Add the public information object to the list (simulating saving to a database)
            _publicInfoList.Add(publicInfo);

            // Return success response
            return Ok(new { success = true, message = "Public information saved successfully." });
        }

        // GET: api/publicinfo/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllPublicInfo()
        {
            // Return all the public information (simulating retrieval from a database)
            return Ok(_publicInfoList);
        }
    }
}
