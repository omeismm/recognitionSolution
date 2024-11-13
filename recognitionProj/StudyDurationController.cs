using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyDurationController : ControllerBase
    {
        // In-memory list to store study duration information temporarily (for demonstration purposes)
        private static List<StudyDuration> _studyDurationList = new List<StudyDuration>();

        // POST: api/studyduration/save
        [HttpPost("save")]
        public IActionResult SaveStudyDuration([FromBody] StudyDuration studyDuration)
        {
            if (studyDuration == null)
            {
                return BadRequest(new { success = false, message = "Invalid study duration data." });
            }

            // Add the study duration object to the list (simulating saving to a database)
            _studyDurationList.Add(studyDuration);

            // Return success response
            return Ok(new { success = true, message = "Study duration saved successfully." });
        }

        // GET: api/studyduration/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllStudyDurations()
        {
            // Return all the study durations (simulating retrieval from a database)
            return Ok(_studyDurationList);
        }
    }
}
