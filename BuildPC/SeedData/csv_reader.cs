using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuildPC.SeedData
{
    public static class csv_reader
    {
        public static List<string> ReadCsvFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<string>();

            return File.ReadAllLines(filePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        }
    }
}
