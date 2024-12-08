using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // In-memory list to store user information temporarily (for demonstration purposes)
        private static List<Users> _userInfoList = new List<Users>();

        // POST: api/users/save
        [HttpPost("save")]
        public IActionResult SaveUserInfo([FromForm] Users userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest(new { success = false, message = "Invalid user information data." });
            }

            // Add the user information object to the list (simulating saving to a database)
            _userInfoList.Add(userInfo);

            // Return success response
            return Ok(new { success = true, message = "User information saved successfully." });
        }

        // GET: api/users/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllUserInfo()
        {
            // Return all the user information (simulating retrieval from a database)
            return Ok(_userInfoList);
        }
    }
}
