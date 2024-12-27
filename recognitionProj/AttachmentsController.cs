using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentsController : ControllerBase
    {
        private readonly string _baseUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        // POST: api/attachments/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile uploadedFile, [FromForm] string subject)
        {
            if (uploadedFile == null || uploadedFile.Length == 0)
            {
                return BadRequest(new { success = false, message = "No file was uploaded." });
            }

            if (string.IsNullOrWhiteSpace(subject))
            {
                return BadRequest(new { success = false, message = "Subject is required." });
            }

            var institutionId = Request.Headers["InstitutionID"].ToString();
            if (string.IsNullOrEmpty(institutionId))
            {
                return BadRequest(new { success = false, message = "Institution ID is required." });
            }

            try
            {
                var institutionFolder = Path.Combine(_baseUploadPath, institutionId);
                if (!Directory.Exists(institutionFolder))
                {
                    Directory.CreateDirectory(institutionFolder);
                }

                var fileName = Path.GetFileNameWithoutExtension(uploadedFile.FileName) + $", {subject}" + Path.GetExtension(uploadedFile.FileName);
                var filePath = Path.Combine(institutionFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

                return Ok(new { success = true, fileName, subject });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ex.Message });
            }
        }

        // GET: api/attachments/list
        [HttpGet("list")]
        public IActionResult GetFiles()
        {
            var institutionId = Request.Headers["InstitutionID"].ToString();
            if (string.IsNullOrEmpty(institutionId))
            {
                return BadRequest(new { success = false, message = "Institution ID is required." });
            }

            var institutionFolder = Path.Combine(_baseUploadPath, institutionId);
            if (!Directory.Exists(institutionFolder))
            {
                return Ok(new { success = true, files = new List<object>() });
            }

            var files = Directory.GetFiles(institutionFolder);
            var fileList = new List<object>();

            foreach (var file in files)
            {
                fileList.Add(new
                {
                    Name = Path.GetFileName(file),
                    Path = $"/api/attachments/view?filePath={Uri.EscapeDataString(file)}"
                });
            }

            return Ok(new { success = true, files = fileList });
        }

        // GET: api/attachments/view
        [HttpGet("view")]
        public IActionResult ViewFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(new { success = false, message = "File not found." });
            }

            var mimeType = "application/octet-stream";
            return PhysicalFile(filePath, mimeType);
        }

        // DELETE: api/attachments/delete
        //todo: CHECK IF THIS WORKS
        [HttpDelete("delete")]
        public IActionResult DeleteFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                return Ok(new { success = true });
            }
            return NotFound(new { success = false, message = "File not found." });
        }
    }
}
