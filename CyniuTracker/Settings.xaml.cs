namespace CyniuTracker;

public partial class Settings : ContentPage
{
	public Settings()
	{
        InitializeComponent();
        BindingContext = MainViewModel.Instance;
    }
    void OnDarkModeToggled(object sender, ToggledEventArgs e)
    {
        App.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }

    private void info_Clicked(object sender, EventArgs e)
    {
        Shell.Current.DisplayAlert("Information", "Created by: Jeremiasz Michorczyk\nDataset by: TMBD\nSpecial Thanks to country of India", "Ok");
    }
}