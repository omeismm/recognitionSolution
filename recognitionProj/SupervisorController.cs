using Microsoft.AspNetCore.Mvc;
using recognitionProj;       // For DatabaseHandler, AcceptanceRecord, etc.
using System;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupervisorController : ControllerBase
    {
        private readonly DatabaseHandler _db;

        public SupervisorController(DatabaseHandler db)
        {
            _db = db;
        }

        // 1) GET /api/supervisor/institution-info?insId=9999
        //    Return relevant info (e.g. from PublicInfo, AcceptanceRecord, etc.)
        [HttpGet("institution-info")]
        public IActionResult GetInstitutionInfo([FromQuery] int insId)
        {
            // Example: fetch "PublicInfo" about the institution
            // (You could fetch from multiple tables if needed.)
            var allPublicInfo = _db.GetAllPublicInfo();
            var thisInstitution = allPublicInfo.Find(pi => pi.InsID == insId);
            if (thisInstitution == null)
                return NotFound(new { success = false, message = $"No institution with InsID={insId} found." });

            // Example: fetch acceptance records (all or only the latest) 
            var allAcceptanceRecords = _db.GetAllAcceptanceRecords();
            // You might store acceptance records keyed by InsID (not in your snippet, but you could).
            // This example returns all records for demonstration. 
            // If you only store them in memory, adapt as needed.

            // Return combined info as an object
            var result = new
            {
                success = true,
                institutionData = thisInstitution,       // Basic public info
                acceptanceRecords = allAcceptanceRecords // Possibly filter by insId
            };
            return Ok(result);
        }

        // 2) PUT /api/supervisor/update-acceptance?insId=9999
        //    Allows the supervisor to update an acceptance record for the institution
        [HttpPut("update-acceptance")]
        public IActionResult UpdateAcceptance([FromQuery] int insId, [FromBody] AcceptanceRecord updatedRecord)
        {
            if (updatedRecord == null)
                return BadRequest(new { success = false, message = "Missing AcceptanceRecord data." });

            // Here you’d do the actual DB update. 
            // If you store acceptance info in a table named AcceptanceRecord, you'd do something like:
            //   1) Find or create that record by InsID
            //   2) Update 'IsAccepted', 'Date', 'Reason', etc.

            // For illustration, let's assume your DatabaseHandler has:
            //   InsertAcceptanceRecord(AcceptanceRecord)
            //   UpdateAcceptanceRecord(AcceptanceRecord, recordId)
            // But you’ll likely want to store each acceptance record with a foreign key to InsID.

            // If you want a single record approach:
            //   - Up to you how you handle "multiple acceptance records" vs. "one record per InsID."

            // For demonstration, let's just do a new insert if accepted or not, skipping the ID logic:
            try
            {
                // Remove old acceptance records for this institution if you want "one record only"
                // Or you keep multiple historical records. It's up to your design.

                // Example: Insert or update a record
                _db.InsertAcceptanceRecord(updatedRecord);

                return Ok(new { success = true, message = "Acceptance record updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}
