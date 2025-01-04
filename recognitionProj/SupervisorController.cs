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

        // PUT: /api/supervisor/update-acceptance?insId=9999
        [HttpPut("update-acceptance")]
        public IActionResult UpdateAcceptance([FromQuery] int insId, [FromBody] AcceptanceRecord updatedRecord)
        {
            Console.WriteLine($"[UpdateAcceptance] Received request for InsID = {insId}.");

            // 1) Validate
            if (updatedRecord == null)
            {
                Console.WriteLine("[UpdateAcceptance] No record data received (null).");
                return BadRequest(new { success = false, message = "Missing AcceptanceRecord data." });
            }

            try
            {
                Console.WriteLine($"[UpdateAcceptance] isAccepted = {updatedRecord.IsAccepted}, date = {updatedRecord.Date}, reason count = {updatedRecord.Reason.Count}");
                Console.WriteLine($"[UpdateAcceptance] Storing new acceptance record in the database.");

                // 2) Insert the new record (maintaining history)
                //    We'll assume your DatabaseHandler method requires storing the InsID somewhere.
                //    For example, you might store it directly in AcceptanceRecord or pass it separately.
                _db.InsertAcceptanceRecord(insId, updatedRecord); // Example method signature

                Console.WriteLine($"[UpdateAcceptance] New acceptance record inserted. Now retrieving all records to see history...");

                // 3) Retrieve all acceptance records for this InsID (for debugging/logging)
                var allRecords = _db.GetAllAcceptanceRecordsByInsId(insId);
                Console.WriteLine($"[UpdateAcceptance] Found {allRecords.Count} acceptance records so far for InsID = {insId}.");

                // 4) If the new record is "accepted," mark AcademicInfo.Accepted = true, otherwise false
                Console.WriteLine($"[UpdateAcceptance] Setting AcademicInfo.Accepted to {updatedRecord.IsAccepted} for InsID = {insId}...");
                _db.UpdateAcademicAccepted(insId, updatedRecord.IsAccepted);

                // 5) Return success
                Console.WriteLine("[UpdateAcceptance] All steps completed successfully.");
                return Ok(new { success = true, message = "Acceptance record updated successfully." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdateAcceptance] Exception occurred: {ex.Message}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}
