namespace ChuckSWWeb.Models.StarWars
{
    public class Person
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string HomeWorld { get; set; }
        public IEnumerable<Film> Films { get; set; }
        public IEnumerable<Species> Species { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<Starship> Starships { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }
    }
}
