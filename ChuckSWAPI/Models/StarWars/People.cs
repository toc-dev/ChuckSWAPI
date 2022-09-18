namespace ChuckSWAPI.Models.StarWars
{
    public class People
    {
        public int Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public Result[] Results { get; set; }
    }

    public class Result
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string Hair_Color { get; set; }
        public string Skin_Color { get; set; }
        public string Eye_Color { get; set; }
        public string Birth_Year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public string[] Films { get; set; }
        public string[] Species { get; set; }
        public object[] Vehicles { get; set; }
        public object[] Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
