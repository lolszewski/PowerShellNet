namespace PowerShellNet.Common.Interfaces
{
    public interface IPowerShellConfigurationService
    {
        T GetSettingOrDefault<T>(string appSettingName, T defaultValue);
    }
}
