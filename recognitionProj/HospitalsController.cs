using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalsController : ControllerBase
    {
        // In-memory list to store hospital information temporarily (for demonstration purposes)
        private static List<Hospitals> _hospitalList = new List<Hospitals>();

        // POST: api/hospitals/save
        [HttpPost("save")]
        public IActionResult SaveHospital([FromForm] Hospitals hospital)
        {
            if (hospital == null)
            {
                return BadRequest(new { success = false, message = "Invalid hospital data." });
            }

            // Add the hospital object to the list (simulating saving to a database)
            _hospitalList.Add(hospital);

            // Return success response
            return Ok(new { success = true, message = "Hospital information saved successfully." });
        }

        // GET: api/hospitals/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllHospitals()
        {
            // Return all the hospital information (simulating retrieval from a database)
            return Ok(_hospitalList);
        }
    }
}
