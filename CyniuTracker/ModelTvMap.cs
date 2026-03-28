using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyniuTracker
{
    public class ModelTvMap : ClassMap<ModelTv>
    {
        public ModelTvMap()
        {
            Map(r => r.id).Name("id");
            Map(r => r.name).Name("name");
            Map(r => r.number_of_seasons).Name("number_of_seasons");
            Map(r => r.number_of_episodes).Name("number_of_episodes");
            Map(r => r.overview).Name("overview");
            Map(r => r.adult).Name("adult");
            Map(r => r.backdrop_path).Name("backdrop_path");
            Map(r => r.in_production).Name("in_production");
            Map(r => r.poster_path).Name("poster_path");
            Map(r => r.genres).Name("genres");
            Map(r => r.episode_run_time).Name("episode_run_time");

        }
    }
}
