using ChuckSWAPI.Models;
using ChuckSWAPI.Models.StarWars;
using ChuckSWAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSWAPI.Controllers
{
    [ApiController]
    [Route("swapi")]
    public class SwapiController : ControllerBase
    {
        private readonly ISwapi _swapi;
        public SwapiController(ISwapi swapi)
        {
            _swapi = swapi;
        }
        [HttpGet("people")]
        public async Task<ActionResult<People>> GetPeople(int pageNumber=1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var people = await _swapi.GetSwapiPeople(pageNumber);

            return Ok(people);
        }
    }
}
