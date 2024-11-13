using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsAndStuffController : ControllerBase
    {
        // In-memory list to store student information temporarily (for demonstration purposes)
        private static List<StudentsAndStuff> _studentInfoList = new List<StudentsAndStuff>();

        // POST: api/studentsandstuff/save
        [HttpPost("save")]
        public IActionResult SaveStudentInfo([FromBody] StudentsAndStuff studentInfo)
        {
            if (studentInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid student information data." });
            }

            // Add the student information object to the list (simulating saving to a database)
            _studentInfoList.Add(studentInfo);

            // Return success response
            return Ok(new { success = true, message = "Student information saved successfully." });
        }

        // GET: api/studentsandstuff/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllStudentInfo()
        {
            // Return all the student information (simulating retrieval from a database)
            return Ok(_studentInfoList);
        }
    }
}
