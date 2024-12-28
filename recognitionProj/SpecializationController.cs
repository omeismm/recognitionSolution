using Microsoft.AspNetCore.Mvc;
using recognitionProj;
using System.Collections.Generic;

namespace RecognitionProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        private static List<Specialization> _specializationList = new List<Specialization>();
        public List<Specialization> SpecializationList { get => _specializationList; set => _specializationList = value; }

        private readonly Verifier _verifier;
        //private readonly DatabaseHandler _databaseHandler;

        // Inject Verifier and DatabaseHandler via constructor
        public SpecializationController(Verifier verifier/*, DatabaseHandler databaseHandler*/)
        {
            _verifier = verifier;
            //_databaseHandler = databaseHandler;
        }


        // POST: api/specialization/save
        [HttpPost("save")]
        public IActionResult SaveSpecialization([FromBody] Specialization specialization)
        {
            if (specialization == null)
            {
                return BadRequest(new { success = false, message = "Invalid specialization data." });
            }

            // Run the ratio logic before adding or after adding
            if (specialization.Type == "Scientific Bachelor")
            {
            _verifier.ScientificBachelorRatio(specialization);

            // Add the specialization object to the list
            _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color
                
            }
            if (specialization.Type == "Humanitarian Bachelor")
            {
                _verifier.HumanitarianBachelorRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color

            }
            if (specialization.Type == "Scientific Practical Bachelor")
            {
                _verifier.ScientificPracticalBachelorRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color

            }
            if (specialization.Type == "Humanitarian Practical Bachelor")
            {
                _verifier.HumnamitarianPracticalBachelorRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color

            }
            if (specialization.Type == "High Diploma")
            {
                _verifier.HighDiplomaRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color
                
            }
            if (specialization.Type == "Scientific Masters")
            {
                _verifier.ScientificMastersRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color
                
            }
            if (specialization.Type == "Scientific Practical Masters")
            {
                _verifier.ScientificPracticalMastersRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color

            }
            if (specialization.Type == "Humanitarian Masters")
            {
                _verifier.HumanitarianMastersRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color

            }
            if (specialization.Type == "Main Medical")
            {
                _verifier.MainMedicalRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color

            }
            if (specialization.Type == "Residency")
            {
                _verifier.ResidencyRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color

            }
           
            if (specialization.Type == "Doctorate")
            {
                _verifier.DoctorateRatio(specialization);

                // Add the specialization object to the list
                _specializationList.Add(specialization);
                //_databaseHandler.InsertSpecialization(specialization);

                // Return the entire specialization object so the frontend can see the updated Color

            }

            return Ok(specialization);
        }

        // GET: api/specialization/get-all
        [HttpGet("get-all")]
        public IActionResult GetAllSpecializations()
        {
            return Ok(_specializationList);
        }

        // GET: api/specialization/get-by-type/{type}
        [HttpGet("get-by-type/{type}")]
        public IActionResult GetSpecializationByType(string type)
        {
            var specializations = _specializationList.FindAll(s => s.Type.Equals(type, System.StringComparison.OrdinalIgnoreCase));
            if (specializations.Count == 0)
            {
                return NotFound(new { success = false, message = $"No specializations found for type '{type}'." });
            }
            return Ok(specializations);
        }

        // DELETE: api/specialization/delete-by-type/{type}
        [HttpDelete("delete-by-type/{type}")]
        public IActionResult DeleteSpecializationByType(string type)
        {
            var specializationsRemoved = _specializationList.RemoveAll(s => s.Type.Equals(type, System.StringComparison.OrdinalIgnoreCase));
            if (specializationsRemoved == 0)
            {
                return NotFound(new { success = false, message = $"No specializations found for type '{type}'." });
            }

            return Ok(new { success = true, message = $"All specializations of type '{type}' deleted successfully." });
        }

    }
}
