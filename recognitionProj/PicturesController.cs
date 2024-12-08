using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PicturesController : ControllerBase
    {
        // In-memory list to store picture information temporarily (for demonstration purposes)
        private static List<Pictures> _pictureInfoList = new List<Pictures>();

        // POST: api/pictures/save
        [HttpPost("save")]
        public IActionResult SavePictureInfo([FromForm] Pictures pictureInfo)
        {
            if (pictureInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid picture information data." });
            }

            // Add the picture information object to the list (simulating saving to a database)
            _pictureInfoList.Add(pictureInfo);

            // Return success response
            return Ok(new { success = true, message = "Picture information saved successfully." });
        }

        // GET: api/pictures/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllPictureInfo()
        {
            // Return all the picture information (simulating retrieval from a database)
            return Ok(_pictureInfoList);
        }
    }
}
