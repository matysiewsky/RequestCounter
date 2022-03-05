using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.Services
{
    public class Stats
    {
        /// <summary>
        /// Dictionary holding statistics of methods execution. key is method name: GET,PUT etc. 
        /// value is and integer number representing number of executions
        /// </summary>
        public Dictionary<string, int> Counts { get;  set; }
    }
}
