using CommunityToolkit.Maui;
using Fitness.Services;
using Microsoft.Extensions.Logging;

namespace Fitness;

public static class MauiProgram
{
    static IServiceProvider serviceProvider;

    public static TService GetService<TService>()
        => serviceProvider.GetService<TService>();

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<ISettingsService, SettingsService>();
        builder.Services.AddSingleton<IFollowsService, FollowsService>();
        builder.Services.AddSingleton<ITrackRecordsService, TrackRecordsService>();
        builder.Services.AddSingleton<IUsersService, UsersService>();

        var app = builder.Build();
        serviceProvider = app.Services;

        return app;
    }
}
