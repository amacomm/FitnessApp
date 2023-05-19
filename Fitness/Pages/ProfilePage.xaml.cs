namespace Fitness.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditProfilePage());
    }

    private async void Subscriptions_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new UsersPage());
    }
    private async void Subscribers_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new UsersPage());
    }
}