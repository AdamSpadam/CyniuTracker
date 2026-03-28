using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CyniuTracker
{
    public static class TvReader
    {
        public static IEnumerable<ModelTv> ReadCsvFile()
        {
            var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                Delimiter = ","
            };
            using var reader = new StreamReader("TMDB_tv_dataset_v3.csv");
            using var csv = new CsvHelper.CsvReader(reader, conf);
            csv.Context.RegisterClassMap<ModelTvMap>();
            var records = csv.GetRecords<ModelTv>();
            return records;

        }
    }
}
