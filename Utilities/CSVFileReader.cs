using CodeTest.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Utilities
{
    public static class CSVFileReader
    {
        public static async Task<List<T>> Read<T>(string path)
        {
            List<T> records;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                 records = csv.GetRecords<T>().ToList<T>();
            }

            return records;
        }
    }
}
