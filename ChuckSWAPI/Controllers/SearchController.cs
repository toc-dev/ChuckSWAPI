using ChuckSWAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSWAPI.Controllers
{
    [ApiController]
    [Route("search")]
    public class SearchController : ControllerBase
    {
        private readonly IChuckNorris _chuckNorris;
        private readonly ISwapi _swapi;

        public SearchController(IChuckNorris chuckNorris, ISwapi swapi)
        {
            _chuckNorris = chuckNorris;
            _swapi = swapi;
        }

        [HttpGet("SearchChuckSWApi")]
        public async Task<IActionResult> SearchChuckSWApi(string searchTerm)
        {
            var searchPeople = await _swapi.SearchSwapiPeople(searchTerm);
            return Ok(searchPeople);
        }
        
        [HttpGet("SearchChuck")]
        public async Task<IActionResult> SearchSWA(string searchTerm)
        {
            var searchPeople = await _chuckNorris.SearchJoke(searchTerm);
            return Ok(searchPeople);
        }
    }
}
