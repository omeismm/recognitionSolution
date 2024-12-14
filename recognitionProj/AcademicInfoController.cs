using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademicInfoController : ControllerBase
    {
        // In-memory list to store academic information temporarily (for demonstration purposes)
        private static List<AcademicInfo> _academicInfoList = new List<AcademicInfo>();

        // POST: api/academicinfo/save
        [HttpPost("save")]
        public IActionResult SaveAcademicInfo([FromBody] AcademicInfo academicInfo)
        {
            if (academicInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid academic information data." });
            }

            // Add the academic information object to the list (simulating saving to a database)
            _academicInfoList.Add(academicInfo);

            // Return success response
            return Ok(new { success = true, message = "Academic information saved successfully." });
        }

        // GET: api/academicinfo/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllAcademicInfo()
        {
            // Return all the academic information (simulating retrieval from a database)
            return Ok(_academicInfoList);
        }

    }


}
