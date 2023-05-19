using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Fitness.Resources.Lenguages;

namespace Fitness.Pages;

public partial class HomePage : ContentPage
{
    //public ObservableCollection<Treck> trecks { get; set; } = new ObservableCollection<Treck>();
    public HomePage()
	{
		InitializeComponent();
        BindingContext = this;
        //collectionView.SetBinding(ItemsView.ItemsSourceProperty, "trecks");
    }

    private void refreshView_Refreshing(object sender, EventArgs e)
    {

        refreshView.IsRefreshing = false;
    }

    public async Task<FileResult> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("gpx", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { DevicePlatform.Android, new[] { "text/*" } }, // MIME type
                });

        PickOptions options = new()
        {
            PickerTitle = "Please select a gpx file",
            FileTypes = customFileType,
        };
        var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
        if(status == PermissionStatus.Granted)
        {
            PickAndShow(options);
            await Navigation.PushModalAsync(new NavigationPage(new SaveDataPage()));
        }
        else
        {
            status = await Permissions.RequestAsync<Permissions.StorageRead>();
            if(status == PermissionStatus.Granted)
            {
                PickAndShow(options);
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

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new TraningPage());
    }
}