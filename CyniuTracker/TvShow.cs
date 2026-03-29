using System;
using System.Collections.Generic;
using System.Text;

namespace CyniuTracker
{
    public class TvShow
    {
        public string id { get; set; }
        public string name { get; set; }
        public int number_of_seasons { get; set; }
        public int number_of_episodes { get; set; }
        public string overview { get; set; }
        public string backdrop_path { get; set; }
        public string poster_path { get; set; }
        public string genres { get; set; } 
    }

}
