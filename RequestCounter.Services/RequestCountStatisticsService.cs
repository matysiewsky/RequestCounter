using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.Services
{
    /// <summary>
    /// Use this class to implement IRequestCountStatsService
    /// </summary>
    public class RequestCountStatisticsService: IRequestCountStatsService
    {
        private Dictionary<string, int> Statistics { get; } = new Dictionary<string, int>();
        private static readonly string[] AllowedMethods = { "GET", "POST", "DELETE", "PUT" };

        public void IncreaseCounter(string method)
        {
            if (!AllowedMethods.Contains(method))
                throw new InvalidOperationException($"Method {method} is not supported.");

            if (Statistics.ContainsKey(method))
                Statistics[method]++;
            else
                Statistics[method] = 1;
        }

        public Stats GetStatistics()
        {
            return new Stats() { Counts = Statistics };
        }
    }
}
