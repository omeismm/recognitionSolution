using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly DatabaseHandler _dbHandler;
        // In-memory list to store library information temporarily (for demonstration purposes)
        public LibraryController(DatabaseHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }
        // POST: api/library/save
        [HttpPost("save")]
        public IActionResult SaveLibraryInfo([FromBody] Library libraryInfo)
        {
            if (libraryInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid library information data." });
            }
            _dbHandler.InsertLibrary(libraryInfo);

            // Return success response
            return Ok(new { success = true, message = "Library information saved successfully." });
        }

        // GET: api/library/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllLibraryInfo()
        {
            // Return all the library information (simulating retrieval from a database)
            //return Ok(_libraryInfoList);
            return Ok();
        }
    }
}
