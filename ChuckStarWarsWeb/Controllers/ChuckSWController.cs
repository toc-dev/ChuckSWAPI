using AutoMapper;
using ChuckSWShared.Dtos;
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

        public ChuckSWController(IChuckService chuckService, IStarWarsService starWarsService, ISearchService searchService)
        {
            _chuckService = chuckService;
            _starWarsService = starWarsService;
            _searchService = searchService;

        }
        public async Task<IActionResult> GetJokeCategories()
        {
            var response = await _chuckService.GetAll();
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        public async Task<IActionResult> DisplayRandomJoke()
        {
            var response = await _chuckService.GetRandomJoke();
            return Ok(response);
        }


        public async Task<IActionResult> GetStarWarsPeople()
        {
            var response = await _starWarsService.GetAll();
            if (response != null)
            {
                return View(response);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SearchChuckNorrisAndStarWars()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SearchChuckNorrisAndSW(string searchTerm)
        {
            var search = await _searchService.GetSearchResult(searchTerm);
            return View(search);
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchChuckNorrisAndSW()
        {
            return View();
        }
    }
}
