using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CyniuTracker;
using System.Collections.ObjectModel;

public partial class MainViewModel : ObservableObject
{
    List<TvShow> _allShowsRaw = new();

    [ObservableProperty]
    ObservableCollection<TvShow> filteredShows = new();

    [ObservableProperty]
    string searchText = string.Empty;

    [ObservableProperty]
    string hometype = "Popular Shows";
    public MainViewModel()
    {
        _ = LoadData();
    }

    public async Task LoadData()
    {
        var data = await TvShowLoader.LoadTvShowsAsync();
        _allShowsRaw = data;
        FilteredShows = new ObservableCollection<TvShow>(_allShowsRaw.Take(10));
    }

    partial void OnSearchTextChanged(string value)
    {
        ApplyFilter(value);
    }
    private void ApplyFilter(string? query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            Hometype = "Popular Shows";
            FilteredShows = new ObservableCollection<TvShow>(_allShowsRaw.Take(10));

        }
        else
        {
            Hometype = "Searching";
            var lower = query.ToLower();
            var filtered = _allShowsRaw
                .Where(s => s.name?.ToLower().Contains(lower) == true)
                .Take(15)
                .ToList();

            FilteredShows = new ObservableCollection<TvShow>(filtered);
        }
    }
}