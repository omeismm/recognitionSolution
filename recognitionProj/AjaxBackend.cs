using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace recognitionProj
{
    public class AjaxBackend//before we continue and use this, lets understand what we are doing here. we need to sanitize the code/json too
    {
        private readonly HttpClient _httpClient;

        public AjaxBackend()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> SaveUniversityAsync(University university)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(university);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost/api/save-university", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving university: {ex.Message}");
                return false;
            }
        }

       
    }
}


[ApiController]
[Route("api/[controller]")]
public class UniversityController : ControllerBase
{
    [HttpPost("save-university")]
    public IActionResult SaveUniversity([FromBody] University university)
    {
        if (university == null)
        {
            return BadRequest("Invalid university data.");
        }

        // Save the university data (to a database or any other logic)
        // For now, we just return success.
        return Ok(new { success = true, message = "University saved successfully" });
    }
}
