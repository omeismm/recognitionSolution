using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;


namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        // In-memory list to store country information temporarily (for demonstration purposes)
        private static List<string> _countryList = new List<string>();

        // POST: api/countries/save
        [HttpPost("save")]
        public IActionResult SaveCountry([FromForm] string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                return BadRequest(new { success = false, message = "Invalid country data." });
            }

            // Add the country to the list (simulating saving to a database)
            _countryList.Add(country);

            // Return success response
            return Ok(new { success = true, message = "Country saved successfully." });
        }

        // GET: api/countries/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllCountries()
        {
            // Return all the countries (simulating retrieval from a database)
            return Ok(_countryList);
        }
    }
}
