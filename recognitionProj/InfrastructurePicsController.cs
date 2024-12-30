using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfrastructurePicsController : ControllerBase
    {
        private readonly string _baseUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        // POST: api/infrastructurepics/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile uploadedFile, [FromForm] string subject)
        {
            Debug.WriteLine("[UploadFile] Upload initiated.");

            if (uploadedFile == null || uploadedFile.Length == 0)
            {
                Debug.WriteLine("[UploadFile] No file uploaded.");
                return BadRequest(new { success = false, message = "No file was uploaded." });
            }

            if (!uploadedFile.ContentType.StartsWith("image/"))
            {
                return BadRequest(new { success = false, message = "Only image files allowed." });
            }

            Debug.WriteLine($"[UploadFile] File name: {uploadedFile.FileName}, Subject: {subject}");

            var institutionId = Request.Headers["InstitutionID"].ToString();
            if (string.IsNullOrEmpty(institutionId))
            {
                Debug.WriteLine("[UploadFile] Institution ID is missing.");
                return BadRequest(new { success = false, message = "Institution ID is required." });
            }

            try
            {
                // Create folder path: wwwroot/uploads/{InstitutionID}/infrastructurepics
                var institutionFolder = Path.Combine(_baseUploadPath, institutionId, "infrastructurepics");
                if (!Directory.Exists(institutionFolder))
                {
                    Directory.CreateDirectory(institutionFolder);
                }

                var fileName = Path.GetFileNameWithoutExtension(uploadedFile.FileName) + $", {subject}" + Path.GetExtension(uploadedFile.FileName);
                var filePath = Path.Combine(institutionFolder, fileName);

                Debug.WriteLine($"[UploadFile] Saving file to: {filePath}");

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

                return Ok(new { success = true, fileName, subject });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[UploadFile] Exception: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ex.Message });
            }
        }

        // GET: api/infrastructurepics/list
        [HttpGet("list")]
        public IActionResult GetFiles()
        {
            var institutionId = Request.Headers["InstitutionID"].ToString();
            if (string.IsNullOrEmpty(institutionId))
            {
                return BadRequest(new { success = false, message = "Institution ID is required." });
            }

            var infrastructurepicsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", institutionId, "infrastructurepics");
            if (!Directory.Exists(infrastructurepicsFolder))
            {
                return Ok(new { success = true, files = new List<object>() });
            }

            var files = Directory.GetFiles(infrastructurepicsFolder);
            var fileList = new List<object>();

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var splitFileName = fileName.Split(", ");
                var subject = splitFileName.Length > 1 ? splitFileName[1].Replace(Path.GetExtension(fileName), "") : "N/A";

                fileList.Add(new
                {
                    Name = fileName,
                    Subject = subject,
                    Path = $"/uploads/{institutionId}/infrastructurepics/{fileName}", // Correct public path
                    DeletePath = $"/api/infrastructurepics/delete?filePath=/uploads/{institutionId}/infrastructurepics/{Uri.EscapeDataString(fileName)}" // Delete endpoint
                });
            }

            return Ok(new { success = true, files = fileList });
        }


        // DELETE: api/infrastructurepics/delete
        [HttpDelete("delete")]
        public IActionResult DeleteFile([FromQuery] string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return BadRequest(new { success = false, message = "File path is required." });
            }

            // If filePath = "/uploads/{InsID}/infrastructurepics/SomeFile.pdf"
            var physicalPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                filePath.TrimStart('/')
            );

            if (System.IO.File.Exists(physicalPath))
            {
                System.IO.File.Delete(physicalPath);
                return Ok(new { success = true });
            }

            return NotFound(new { success = false, message = "File not found." });
        }



    }
}
