namespace CyniuTracker;

public partial class Ustawienia : ContentPage
{
	public Ustawienia()
	{
		InitializeComponent();
	}
    void OnDarkModeToggled(object sender, ToggledEventArgs e)
    {
        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }

}