using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Fitness.Resources.Lenguages;

namespace Fitness.Pages;

public partial class RecordsPage : ContentPage
{
	public RecordsPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var status = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
        var status_storage = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
        if (status == PermissionStatus.Granted)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SaveDataPage()));
        }
        else
        {
            status = await Permissions.RequestAsync<Permissions.LocationAlways>();
            status_storage = await Permissions.RequestAsync<Permissions.StorageWrite>();
            if (status == PermissionStatus.Granted)
            {
                await Navigation.PushAsync(new SaveDataPage());
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                string text = Localisation.Permission;
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;

                var toast = Toast.Make(text, duration, fontSize);

                await toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}