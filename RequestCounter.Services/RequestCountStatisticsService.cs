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
        private Dictionary<string, int> Statistics { get; set; } = new Dictionary<string, int>();
        private static readonly string[] AllowedMethods = { "GET", "POST", "DELETE", "PUT" };
        private object _lock = new object();

        public void IncreaseCounter(string method)
        {
            lock (_lock)
            {
                if (!AllowedMethods.Contains(method))
                    throw new InvalidOperationException($"Method {method} is not supported.");

                if (Statistics.ContainsKey(method))
                    Statistics[method]++;
                else
                    Statistics[method] = 1;
                DataReader.WriteToFile(Statistics);
            }

        }

        public Stats GetStatistics()
        {
            lock (_lock)
            {
                Statistics = DataReader.ReadFromFile();
                return new Stats() { Counts = Statistics };
            }
        }
    }
}
