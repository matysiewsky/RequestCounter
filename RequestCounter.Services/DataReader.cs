using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RequestCounter.Services
{
    /// <summary>
    /// This class is supposed to be implemented as part of TASK "Save counts". Pay attention to setting of the file added to project
    /// </summary>
    internal static class DataReader
    {
        private static readonly string fileName = "request-counts.txt";

        internal static Dictionary<string, int> ReadFromFile()
        {
           var lines = File.ReadAllLines(GetFullFilePath());
           Dictionary<string, int> stats = new Dictionary<string, int>(); 
           foreach (var line in lines)
            {
                var split = line.Split(',');
                if (split.Length == 2)
                {
                    stats.Add(split[0], int.Parse(split[1]));
                }
            }
            return stats;

        }

        internal static void WriteToFile(Dictionary<string, int> stats)
        {
            List<string> lines = new List<string>();
            foreach(KeyValuePair<string, int> entry in stats)
            {
                lines.Add($"{entry.Key},{entry.Value}");
            }
            File.WriteAllLines(GetFullFilePath(), lines);
        }

        /// <summary>
        /// Use it to resolve full path to the file. 
        /// </summary>
        /// <returns></returns>
        private static string GetFullFilePath()
        {
            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            var fullPath = Path.Combine(filePath, fileName);
            return fullPath;
        }
    }
}
