using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        // In-memory list to store specializations temporarily (for demonstration purposes)
        private static List<Specialization> specializations = new List<Specialization>();

        // POST: api/specialization/save
        [HttpPost("save")]
        public IActionResult SaveSpecialization([FromBody] Specialization specialization)
        {
            if (specialization == null)
            {
                return BadRequest(new { success = false, message = "Invalid specialization data." });
            }

            // Add the specialization object to the list (simulating saving to a database)
            specializations.Add(specialization);

            // Return success response
            return Ok(new { success = true, message = "Specialization saved successfully." });
        }

        // GET: api/specialization/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllSpecializations()
        {
            // Return all the specializations (simulating retrieval from a database)
            return Ok(specializations);
        }
    }
}
