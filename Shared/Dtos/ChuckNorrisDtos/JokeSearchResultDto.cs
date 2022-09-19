using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSWShared.Dtos.ChuckNorrisDtos
{
    public class JokeSearchResultDto
    {
        public int Total { get; set; }
        public SearchResult[] Results { get; set; }
    }

    public class SearchResult
    {
        public object[] Categories { get; set; }
        public string Value { get; set; }
        public string Url { get; set; }
    }
}
