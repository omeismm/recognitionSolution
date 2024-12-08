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
        private static List<University> _universityList = new List<University>();  // Renamed to avoid conflicts

        // POST: api/university/save
        [HttpPost("save")]
        public IActionResult SaveUniversity([FromForm] University university)
        {
            if (university == null)
            {
                return BadRequest(new { success = false, message = "Invalid university data." });
            }

            // Add the university object to the list (simulating saving to a database)
            _universityList.Add(university);

            // Return success response
            return Ok(new { success = true, message = "University saved successfully." });
        }

        // GET: api/university/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllUniversities()
        {
            // Return all the universities (simulating retrieval from a database)
            return Ok(_universityList);
        }

        // GET: api/university/get/{id}
        [HttpGet("get/{id}")]
        public IActionResult GetUniversityById(int id)
        {
            var university = _universityList.Find(u => u.Id == id);
            if (university == null)
            {
                return NotFound(new { success = false, message = "University not found." });
            }

            return Ok(university);
        }

        // DELETE: api/university/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUniversity(int id)
        {
            var university = _universityList.Find(u => u.Id == id);
            if (university == null)
            {
                return NotFound(new { success = false, message = "University not found." });
            }

            _universityList.Remove(university);

            return Ok(new { success = true, message = "University deleted successfully." });
        }
    }
}
