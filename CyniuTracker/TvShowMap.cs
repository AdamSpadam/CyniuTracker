using CsvHelper.Configuration;
using CyniuTracker;

public class TvShowMap : ClassMap<TvShow>
{
    public TvShowMap()
    {
        Map(m => m.id).Name("id");
        Map(m => m.name).Name("name");
        Map(m => m.number_of_seasons).Name("number_of_seasons");
        Map(m => m.number_of_episodes).Name("number_of_episodes");
        Map(m => m.overview).Name("overview");
        Map(m => m.backdrop_path).Name("backdrop_path");
        Map(m => m.poster_path).Name("poster_path");
        Map(m => m.genres).Name("genres");
        Map(m => m.adult).Name("adult");
    }
}