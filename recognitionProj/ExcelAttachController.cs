using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcelAttachController : ControllerBase
    {
        // In-memory list to store Excel attachments temporarily (for demonstration purposes)
        private static List<ExcelAttachment> _excelAttachmentList = new List<ExcelAttachment>();

        // POST: api/excelattach/save
        [HttpPost("save")]
        public IActionResult SaveExcelAttachment([FromForm] ExcelAttachment excelAttachment)
        {
            if (excelAttachment == null)
            {
                return BadRequest(new { success = false, message = "Invalid Excel attachment data." });
            }

            // Add the Excel attachment object to the list (simulating saving to a database)
            _excelAttachmentList.Add(excelAttachment);

            // Return success response
            return Ok(new { success = true, message = "Excel attachment saved successfully." });
        }

        // GET: api/excelattach/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllExcelAttachments()
        {
            // Return all the Excel attachments (simulating retrieval from a database)
            return Ok(_excelAttachmentList);
        }
    }

    // Example model class for ExcelAttachment (for demonstration purposes)
    public class ExcelAttachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
