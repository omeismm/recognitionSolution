using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase
    {
        // In-memory list to store universities temporarily (for demonstration purposes)
        private static List<University> universities = new List<University>();

        // POST: api/university/save
        [HttpPost("save")]
        public IActionResult SaveUniversity([FromBody] University university)
        {
            if (university == null)
            {
                return BadRequest(new { success = false, message = "Invalid university data." });
            }

            // Add the university object to the list (simulating saving to a database)
            universities.Add(university);

            // Return success response
            return Ok(new { success = true, message = "University saved successfully." });
        }

        // GET: api/university/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllUniversities()
        {
            // Return all the universities (simulating retrieval from a database)
            return Ok(universities);
        }
    }
}
