using Fitness.Services;

namespace Fitness.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly IUsersService _usersService;

	public ProfilePage() : this(MauiProgram.GetService<IUsersService>())
	{
		InitializeComponent();
    }

    public ProfilePage(IUsersService usersService)
    {
        _usersService = usersService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var users = await _usersService.ApiUsersGet();
        SubscriptionsCount.Text = users.Count.ToString();
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