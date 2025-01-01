using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/generalinfo")]
    public class GeneralInfoController : ControllerBase
    {
        private readonly string _baseUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        // POST: api/generalinfo/upload_all
        [HttpPost("upload_all")]
        public async Task<IActionResult> UploadAll([FromForm] IFormFile faculties, [FromForm] IFormFile programs, [FromForm] IFormFile students, [FromForm] IFormFile staff)
        {
            var institutionId = Request.Headers["InstitutionID"].ToString();
            if (string.IsNullOrEmpty(institutionId))
            {
                return BadRequest(new { success = false, message = "Institution ID is required." });
            }

            // Base folder for this institution
            var institutionFolder = Path.Combine(_baseUploadPath, institutionId);
            Directory.CreateDirectory(institutionFolder);

            // List of allowed file extensions
            var allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".xls", ".xlsx", ".csv" };

            async Task<bool> ValidateAndSaveFileAsync(IFormFile file, string fileNamePrefix)
            {
                if (file != null && file.Length > 0)
                {
                    // Validate file extension
                    var fileExtension = Path.GetExtension(file.FileName);
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        return false;
                    }

                    // Append timestamp to file name
                    
                    var filePath = Path.Combine(institutionFolder, $"{fileNamePrefix} {fileExtension}");

                    using var stream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(stream);
                    return true;
                }
                return false;
            }

            // Validate and save each file
            bool facultiesValid = await ValidateAndSaveFileAsync(faculties, "Faculties");
            bool programsValid = await ValidateAndSaveFileAsync(programs, "Programs");
            bool studentsValid = await ValidateAndSaveFileAsync(students, "Students");
            bool staffValid = await ValidateAndSaveFileAsync(staff, "Staff");

            if (!facultiesValid || !programsValid || !studentsValid || !staffValid)
            {
                return BadRequest(new { success = false, message = "One or more files have invalid types. Allowed file types are: .xls, .xlsx, .csv" });
            }

            return Ok(new { success = true, message = "All files uploaded successfully." });
        }


        // GET: api/generalinfo/list
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

            var fileList = new List<object>();

            foreach (var file in Directory.GetFiles(institutionFolder))
            {
                var fileName = Path.GetFileName(file);
                fileList.Add(new
                {
                    Name = fileName,
                    Path = $"/uploads/{institutionId}/{fileName}",
                    DeletePath = $"/api/generalinfo/delete?filePath=/uploads/{institutionId}/{Uri.EscapeDataString(fileName)}"
                });
            }

            return Ok(new { success = true, files = fileList });
        }

        // DELETE: api/generalinfo/delete
        [HttpDelete("delete")]
        public IActionResult DeleteFile([FromQuery] string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return BadRequest(new { success = false, message = "File path is required." });
            }

            var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.TrimStart('/'));
            if (System.IO.File.Exists(physicalPath))
            {
                System.IO.File.Delete(physicalPath);
                return Ok(new { success = true, message = "File deleted successfully." });
            }

            return NotFound(new { success = false, message = "File not found." });
        }
    }
}
