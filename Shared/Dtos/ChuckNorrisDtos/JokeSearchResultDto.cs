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
        public Result[] Result { get; set; }
    }

    public class Result
    {
        public object[] Categories { get; set; }
        public string Value { get; set; }
    }
}
