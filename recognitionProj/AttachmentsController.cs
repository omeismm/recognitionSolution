using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
//BTW THIS HAS NOTHING TO DO WITH THE ATTACHMENTS CLASS
//BTW THIS HAS NOTHING TO DO WITH THE ATTACHMENTS CLASS
//BTW THIS HAS NOTHING TO DO WITH THE ATTACHMENTS CLASS
//BTW THIS HAS NOTHING TO DO WITH THE ATTACHMENTS CLASS
//BTW THIS HAS NOTHING TO DO WITH THE ATTACHMENTS CLASS
namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentsController : ControllerBase
    {
        // POST: api/attachments/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile uploadedFile, [FromForm] string subject)
        {
            // Basic checks
            if (uploadedFile == null || uploadedFile.Length == 0)
            {
                return BadRequest(new { success = false, message = "No file was uploaded." });
            }

            // This subject parameter is from the <input type="text" name="subject"> in the HTML
            if (string.IsNullOrWhiteSpace(subject))
            {
                return BadRequest(new { success = false, message = "Subject is required." });
            }

            try
            {
                // Example: Save the file to the local "Uploads" folder (ensure it exists or create it)
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Create a unique filename; you could also keep the original name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadedFile.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

                // Here you could store `subject` and `fileName` in a database, etc.

                // Return success
                return Ok(new { success = true, message = "File uploaded successfully." });
            }
            catch (Exception ex)
            {
                // Log the exception, then return error
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { success = false, message = "File upload failed.", detail = ex.Message });
            }
        }
    }
}
