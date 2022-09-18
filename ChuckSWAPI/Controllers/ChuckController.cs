using ChuckSWAPI.Models.ChuckNorris;
using ChuckSWAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSWAPI.Controllers
{
    [ApiController]
    [Route("chuck")]
    public class ChuckController : ControllerBase
    {
        private readonly IChuckNorris _chuckNorris;
        public ChuckController(IChuckNorris chuckNorris)
        {
            _chuckNorris = chuckNorris;
        }
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<JokeCategories>>> Jokes()
        {
            var allJokes = await _chuckNorris.GetJokeCategories();
            return Ok(allJokes);
        }
        [HttpGet("randomJoke")]
        public async Task<ActionResult<RandomJoke>> GetRandomJoke()
        {
            var randomJoke = await _chuckNorris.GetRandomJoke();
            return Ok(randomJoke);
        }


    }
}
