﻿using ChuckSWAPI.Models;
using ChuckSWAPI.Models.StarWars;
using ChuckSWAPI.Services.Interfaces;
using Newtonsoft.Json;

namespace ChuckSWAPI.Services.Implementations
{
    public class Swapi : ISwapi
    {
        private const string baseAddress = "https://swapi.dev/api/people/";
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<People> GetSwapiPeople()
        {

            HttpResponseMessage response = await _httpClient.GetAsync(baseAddress);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            People people = JsonConvert.DeserializeObject<People>(content);


            return people;
        }
    }
}