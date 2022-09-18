using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSWShared.Dtos.ChuckNorrisDtos
{
    public class RandomJokeDto
    {
        public class RandomJoke
        {
            public object[] categories { get; set; }
            public string Value { get; set; }
        }
}
