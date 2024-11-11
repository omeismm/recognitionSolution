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
        private static List<Specialization> _specializationList = new List<Specialization>();

        // POST: api/specialization/save
        [HttpPost("save")]
        public IActionResult SaveSpecialization([FromBody] Specialization specialization)
        {
            if (specialization == null)
            {
                return BadRequest(new { success = false, message = "Invalid specialization data." });
            }

            // Add the specialization object to the list (simulating saving to a database)
            _specializationList.Add(specialization);

            // Return success response
            return Ok(new { success = true, message = "Specialization saved successfully." });
        }

        // GET: api/specialization/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllSpecializations()
        {
            // Return all the specializations (simulating retrieval from a database)
            return Ok(_specializationList);
        }

        // GET: api/specialization/get-by-type/{type}
        [HttpGet("get-by-type/{type}")]
        public IActionResult GetSpecializationByType(string type)
        {
            // Use the Type property instead of GetType() to access the _type field
            var specializations = _specializationList.FindAll(s => s.Type.Equals(type, System.StringComparison.OrdinalIgnoreCase));

            if (specializations.Count == 0)
            {
                return NotFound(new { success = false, message = $"No specializations found for type '{type}'." });
            }

            return Ok(specializations);
        }

        // DELETE: api/specialization/delete-by-type/{type}
        [HttpDelete("delete-by-type/{type}")]
        public IActionResult DeleteSpecializationByType(string type)
        {
            // Use the Type property instead of GetType() to access the _type field
            var specializationsRemoved = _specializationList.RemoveAll(s => s.Type.Equals(type, System.StringComparison.OrdinalIgnoreCase));

            if (specializationsRemoved == 0)
            {
                return NotFound(new { success = false, message = $"No specializations found for type '{type}'." });
            }

            return Ok(new { success = true, message = $"All specializations of type '{type}' deleted successfully." });
        }

    }
}
