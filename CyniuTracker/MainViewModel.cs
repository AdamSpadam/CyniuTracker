using CommunityToolkit.Mvvm.ComponentModel; //peak 
using CommunityToolkit.Mvvm.Input;
using CyniuTracker;
using System.Collections.ObjectModel;

public partial class MainViewModel : ObservableObject
{
    public static MainViewModel Instance { get; } = new MainViewModel();

    List<TvShow> _allShows = new();

    [ObservableProperty]
    ObservableCollection<TvShow> filteredShows = new();

    [ObservableProperty]
    ObservableCollection<TvShow> savedShowData = new();

    [ObservableProperty]
    string searchText = string.Empty;

    [ObservableProperty]
    string hometype = "Popular Shows";


    public MainViewModel()
    {
        _ = LoadData(); //to jest lwk przydatne dzk John Internet
    }

    public async Task LoadData()
    {
        var data = await TvShowLoader.LoadTvShowsAsync();
        _allShows = data;
        FilteredShows = new ObservableCollection<TvShow>(_allShows.Take(10));
        await SavedDataAsync();
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
            FilteredShows = new ObservableCollection<TvShow>(_allShows.Take(10));

        }
        else
        {
            Hometype = "Searching";
            var lower = query.ToLower();
            var filtered = _allShows
                .Where(s => s.name?.ToLower().Contains(lower) == true)
                .Take(15)
                .ToList();

            FilteredShows = new ObservableCollection<TvShow>(filtered);
        }
    }

    private async Task SavedDataAsync()
    {
        var path = FileSystem.AppDataDirectory;
        var fullPath = Path.Combine(path, "file.txt");
        var text = await File.ReadAllLinesAsync(fullPath);
        var idHashSet = text.ToHashSet();
        var shows = _allShows.Where(s => idHashSet.Contains(s.id)).ToList();
        SavedShowData = new ObservableCollection<TvShow>(shows);
        
    }

    [RelayCommand]
    private async Task StartWatching(string value)
    {
        var path = FileSystem.AppDataDirectory;
        var fullPath = Path.Combine(path, "file.txt");
        var lines = (await File.ReadAllLinesAsync(fullPath)).ToHashSet();
        if (!lines.Contains(value))
        {
            await File.AppendAllTextAsync(fullPath, value + Environment.NewLine);
            var show = _allShows.FirstOrDefault(s => s.id == value);
            await SavedDataAsync();
            Shell.Current.DisplayAlert("Started watching a new show", "Hope you will enjoy it ;)", "Ok");
        }
        else
        {
            Shell.Current.DisplayAlert("", "You are already watching this show", "Ok");
        }
    }
    [RelayCommand] 
    private async Task FinishWatching(string value)
    {
        var path = FileSystem.AppDataDirectory;
        var fullPath = Path.Combine(path, "file.txt");
        var lines = await File.ReadAllLinesAsync(fullPath);
        var updated = lines.Where(l => l.Trim() != value).ToList();
        await File.WriteAllLinesAsync(fullPath, updated);
        await SavedDataAsync();
        Shell.Current.DisplayAlert("Finished watching", "Hope you had fun :>", "Ok");
    }
    [RelayCommand]
    private async Task Clear(string value)
    {
        var path = FileSystem.AppDataDirectory;
        var fullPath = Path.Combine(path, "file.txt");
        await File.WriteAllTextAsync(fullPath, "");
        await SavedDataAsync();
    }
}