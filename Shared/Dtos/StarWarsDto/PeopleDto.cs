using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSWShared.Dtos.StarWarsDto
{
    public class PeopleDto
    {
        public int Count { get; set; }
        public PeopleResult[] Results { get; set; }   
    }
    public class PeopleResult
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
