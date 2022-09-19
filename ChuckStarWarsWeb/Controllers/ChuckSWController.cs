using AutoMapper;
using ChuckSWWeb.Models;
using ChuckSWWeb.Models.ChuckNorris;
using ChuckSWWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChuckSWWeb.Controllers
{
    public class ChuckSWController : Controller
    {
        private readonly IChuckService _chuckService;
        private readonly IStarWarsService _starWarsService;
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public ChuckSWController(IChuckService chuckService, IMapper mapper, IStarWarsService starWarsService, ISearchService searchService)
        {
            _chuckService = chuckService;
            _starWarsService = starWarsService;
            _searchService = searchService;

            _mapper = mapper;
        }
        public async Task<IActionResult> GetJokeCategories()
        {
            var response = await _chuckService.GetAll();
            if (response != null)
            {
                return View(response);
            }
            return View("[]");
        }

        public async Task<IActionResult> DisplayRandomJoke()
        {
            var response = await _chuckService.GetRandomJoke(); 
            {
                return View(response); 
            }
            return View("[]");
        }


        public async Task<IActionResult> GetStarWarsPeople()
        {
            var response = await _starWarsService.GetAll();
            if (response != null)
            {
                return View(response);
            }
            return View("[]");
        }

        public async Task<IActionResult> SearchChuckNorrisAndStarWars(string searchTerm)
        {
            var search = _searchService.GetSearchResult(searchTerm);
            return View(search);
        }
    }
}
