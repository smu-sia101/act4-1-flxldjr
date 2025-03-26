using Microsoft.AspNetCore.Mvc;

namespace PetNameGenerator.Controllers
{
    [ApiController]
    [Route("generate")]
    public class PetNameController : ControllerBase
    {
        private string[] dogNames = new string[] { "Buddy", "Max", "Charlie", "Rocky", "Rex" };
        private string[] catNames = new string[] { "Whiskers", "Mittens", "Luna", "Simba", "Tiger" };
        private string[] birdNames = new string[] { "Tweety", "Sky", "Chirpy", "Raven", "Sunny" };

        [HttpPost]
        public IActionResult GeneratePetName([FromBody] PetNameRequest request)
        {
            if (request.animalType == null)
            {
                return BadRequest(new { error = "The 'animalType' field is required." });
            }

            string[] names = new string[] { };

            if (request.animalType == "dog")
            {
                names = dogNames;
            }
            else if (request.animalType == "cat")
            {
                names = catNames;
            }
            else if (request.animalType == "bird")
            {
                names = birdNames;
            }
            else
            {
                return BadRequest(new { error = "Invalid animal type. Allowed values: dog, cat, bird." });
            }

            Random rnd = new Random();
            string petName = names[rnd.Next(names.Length)];

            return Ok(new { name = petName });
        }
    }

    public class PetNameRequest
    {
        public string animalType { get; set; }
    }
}
