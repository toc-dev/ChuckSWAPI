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
        public async Task<ActionResult<People>> GetPeople()
        {
            var people = await _swapi.GetSwapiPeople();
            return Ok(people);
        }
    }
}
