namespace CyniuTracker;

public partial class Settings : ContentPage
{
	public Settings()
	{
        InitializeComponent();
	}
    void OnDarkModeToggled(object sender, ToggledEventArgs e)
    {
        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }

}