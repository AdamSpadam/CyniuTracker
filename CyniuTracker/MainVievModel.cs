using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CyniuTracker
{
    public class MainViewModel
    {
        public ObservableCollection<ModelTv> TvShows { get; set; }

        public MainViewModel()
        {
            var data = TvReader.ReadCsvFile();
            TvShows = new ObservableCollection<ModelTv>(data);
        }
    }
}
