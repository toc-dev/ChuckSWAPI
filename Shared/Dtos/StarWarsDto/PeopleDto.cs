using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSWShared.Dtos.StarWarsDto
{
    public class People
    {
        public int Count { get; set; }
        public Result[] Results { get; set; }
        public class Result
        {
            public string Name { get; set; }
        }
    }
