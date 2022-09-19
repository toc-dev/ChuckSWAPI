using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSWShared.Dtos
{
    public class SearchResultsDto
    {
        public int Total { get; set; }
        public SearchResults[] Results { get; set; }
    }
    public class SearchResults
    {
        public object[] Categories { get; set; }
        public string Value { get; set; }
        public string Url { get; set; }
        public string SearchType { get; set; }
    }
}
