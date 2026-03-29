using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper;

namespace CyniuTracker
{
    public static class TvShowLoader
    {
        public static async Task<List<TvShow>> LoadTvShowsAsync(int maxRecords = 7000)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("TMDB_tv_dataset_v3.csv");
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<TvShowMap>();

            var records = csv.GetRecords<TvShow>()
                             .Take(maxRecords)
                             .ToList();
            return records;
        }
    }
}