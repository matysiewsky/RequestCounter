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
    public class RequestCountStatisticsService
    {     
        //List of methods which are allowed to be counted by designed service
        private static readonly string[] AllowedMethods = new string[] { "GET", "POST", "DELETE", "PATCH", "PUT" };
    }
}
