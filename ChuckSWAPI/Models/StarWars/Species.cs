﻿namespace ChuckSWAPI.Models.StarWars
{
    public class Species
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public string AverageHeight { get; set; }
        public string SkinColors { get; set; }
        public string HairColors { get; set; }
        public string EyeColors { get; set; }
        public string AverageLifespan { get; set; }
        public Planet Homeworld { get; set; }
        public string Language { get; set; }
        public IEnumerable<People> People { get; set; }
        public IEnumerable<Film> Films { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }
    }
}
