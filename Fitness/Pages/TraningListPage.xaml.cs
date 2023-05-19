namespace Fitness.Pages;

public partial class TraningListPage : ContentPage
{
	public TraningListPage()
	{
		InitializeComponent();
	}

    private void refreshView_Refreshing(object sender, EventArgs e)
    {

    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new NavigationPage(new TraningPage()));
    }
}