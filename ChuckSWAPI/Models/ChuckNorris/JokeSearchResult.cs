namespace ChuckSWAPI.Models.ChuckNorris
{

    public class JokeSearchResult
    {
        public int Total { get; set; }
        public Result[] Result { get; set; }
    }

    public class Result
    {
        public object[] Categories { get; set; }
        public string Created_at { get; set; }
        public string Icon_Url { get; set; }
        public string Id { get; set; }
        public string Updated_At { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }

}
