using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcceptanceRecordController : ControllerBase
    {
        // In-memory list to store acceptance records temporarily (for demonstration purposes)
        private static List<AcceptanceRecord> _acceptanceRecordList = new List<AcceptanceRecord>();

        // POST: api/acceptancerecord/save
        [HttpPost("save")]
        public IActionResult SaveAcceptanceRecord([FromBody] AcceptanceRecord acceptanceRecord)
        {
            if (acceptanceRecord == null)
            {
                return BadRequest(new { success = false, message = "Invalid acceptance record data." });
            }

            // Add the acceptance record object to the list (simulating saving to a database)
            _acceptanceRecordList.Add(acceptanceRecord);

            // Return success response
            return Ok(new { success = true, message = "Acceptance record saved successfully." });
        }

        // GET: api/acceptancerecord/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllAcceptanceRecords()
        {
            // Return all the acceptance records (simulating retrieval from a database)
            return Ok(_acceptanceRecordList);
        }
    }
}
