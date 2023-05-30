namespace Fitness.Services;

public interface ISettingsService
{
    string BasePath { get; }
    string AccessToken { get; set; }
}

public class SettingsService : ISettingsService
{
    private const string BasePathKey = "base_path";
    private const string BasePathDefault = "https://dkz1z6k5-7125.euw.devtunnels.ms";

    private const string AccessTokenKey = "access_token";
    private const string AccessTokenDefault = "";

    public string BasePath => Preferences.Get(BasePathKey, BasePathDefault);

    public string AccessToken
    {
        get => Preferences.Get(AccessTokenKey, AccessTokenDefault);
        set => Preferences.Set(AccessTokenKey, value);
    }
}