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
    public class AttachmentsController : ControllerBase
    {
        private readonly string _baseUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        // POST: api/attachments/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile uploadedFile, [FromForm] string subject)
        {
            Debug.WriteLine("[UploadFile] Upload initiated.");

            if (uploadedFile == null || uploadedFile.Length == 0)
            {
                Debug.WriteLine("[UploadFile] No file uploaded.");
                return BadRequest(new { success = false, message = "No file was uploaded." });
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
                var institutionFolder = Path.Combine(_baseUploadPath, institutionId);
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


        // GET: api/attachments/list
        [HttpGet("list")]
        public IActionResult GetFiles()
        {
            var institutionId = Request.Headers["InstitutionID"].ToString();
            Debug.WriteLine($"[GetFiles] Institution ID: {institutionId}");

            if (string.IsNullOrEmpty(institutionId))
            {
                Debug.WriteLine("[GetFiles] Institution ID is missing.");
                return BadRequest(new { success = false, message = "Institution ID is required." });
            }

            var institutionFolder = Path.Combine(_baseUploadPath, institutionId);
            Debug.WriteLine($"[GetFiles] Institution Folder Path: {institutionFolder}");

            if (!Directory.Exists(institutionFolder))
            {
                Debug.WriteLine("[GetFiles] Institution folder does not exist.");
                return Ok(new { success = true, files = new List<object>() });
            }

            var files = Directory.GetFiles(institutionFolder);
            Debug.WriteLine($"[GetFiles] Found {files.Length} file(s).");

            var fileList = new List<object>();

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var splitFileName = fileName.Split(", ");
                var subject = splitFileName.Length > 1 ? splitFileName[1].Replace(Path.GetExtension(fileName), "") : "N/A";

                Debug.WriteLine($"[GetFiles] File: {fileName}, Subject: {subject}");

                fileList.Add(new
                {
                    Name = fileName,
                    Subject = subject,
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
            Debug.WriteLine($"[DeleteFile] Deleting file: {filePath}");

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                Debug.WriteLine("[DeleteFile] File deleted successfully.");
                return Ok(new { success = true });
            }

            Debug.WriteLine("[DeleteFile] File not found.");
            return NotFound(new { success = false, message = "File not found." });
        }

    }
}
