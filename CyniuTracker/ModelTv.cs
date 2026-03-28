using System;
using System.Collections.Generic;
using System.Text;

namespace CyniuTracker
{
    public class ModelTv
    {
        public int id { get; set; }
        public string name { get; set; }
        public int number_of_seasons { get; set; }
        public int number_of_episodes { get; set; }
        public bool overview { get; set; }
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public bool in_production { get; set; }
        public string poster_path { get; set; }
        public string genres { get; set; }
        public string episode_run_time { get; set; }
    }
}
