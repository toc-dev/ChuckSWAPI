﻿namespace ChuckSWWeb.Models.StarWars
{
    public class Film
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public IEnumerable<Person> Characters { get; set; }
        public IEnumerable<Planet> Planets { get; set; }
        public IEnumerable<Starship> Starships { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<Species> Species { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }
    }
}