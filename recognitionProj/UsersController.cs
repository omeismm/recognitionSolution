// File: Controllers/UsersController.cs

using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using recognitionProj.Models; // Ensure this matches your project structure
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult SaveUserInfo([FromBody] Users userInfo)
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

        // POST: api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] MyLoginRequest loginRequest)
        {
            if (loginRequest == null ||
                string.IsNullOrEmpty(loginRequest.Email) ||
                string.IsNullOrEmpty(loginRequest.Password) ||
                string.IsNullOrEmpty(loginRequest.VerificationCode))
            {
                return BadRequest(new { success = false, message = "Invalid login data." });
            }

            // Check if the verification code is correct
            if (loginRequest.VerificationCode != "abc123")
            {
                return BadRequest(new { success = false, message = "Invalid verification code." });
            }

            // 1. Check if user is the hardcoded admin
            if (loginRequest.Email == "admin@admin.com" && loginRequest.Password == "admin")
            {
                // Hardcode the required fields
                return Ok(new
                {
                    success = true,
                    message = "Admin login successful.",
                    insID = 9999,
                    insName = "Admin",
                    clearance = 2, // 0 for university, 1 for supervisor, 2 for master admin
                    speciality = "admin",
                    insCountry = "Admin Country",
                    verified = 1
                });
            }

            // 2. Otherwise, check in-memory list
            var existingUser = _userInfoList.FirstOrDefault(u =>
                u.Email == loginRequest.Email &&
                u.Password == loginRequest.Password);

            if (existingUser == null)
            {
                return Unauthorized(new { success = false, message = "Invalid email or password." });
            }

            // 3. Normal user found
            return Ok(new
            {
                success = true,
                message = "Login successful.",
                insID = existingUser.InsID,
                insName = existingUser.InsName,
                clearance = existingUser.Clearance,
                speciality = existingUser.Speciality,
                insCountry = existingUser.InsCountry,
                verified = existingUser.Verified
            });
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
