namespace Fitness.Pages;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private void Button_Login_Clicked(object sender, EventArgs e)
    {

    }

    private async void Button_Registration_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NavigationPage(new RegistrationPage()));
    }
}