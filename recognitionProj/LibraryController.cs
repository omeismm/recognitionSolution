using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        // In-memory list to store library information temporarily (for demonstration purposes)
        private static List<Library> _libraryInfoList = new List<Library>();

        // POST: api/library/save
        [HttpPost("save")]
        public IActionResult SaveLibraryInfo([FromForm] Library libraryInfo)
        {
            if (libraryInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid library information data." });
            }

            // Add the library information object to the list (simulating saving to a database)
            _libraryInfoList.Add(libraryInfo);

            // Return success response
            return Ok(new { success = true, message = "Library information saved successfully." });
        }

        // GET: api/library/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllLibraryInfo()
        {
            // Return all the library information (simulating retrieval from a database)
            return Ok(_libraryInfoList);
        }
    }
}
