using Microsoft.AspNetCore.Mvc;

namespace PetNameGenerator.Controllers
{
    [ApiController]
    [Route("generate")]
    public class PetNameController : ControllerBase
    {
        private string[] dogNames = new string[] { "Brownie", "Whitie", "Blackie", "Rocky", "Vallen","Tristan" };
        private string[] catNames = new string[] { "Whisky", "Mittens", "Luna", "Souce", "Trix" };
        private string[] birdNames = new string[] { "Tweetie", "Skay", "Chirpie", "Rayven", "Sunnie" };

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
