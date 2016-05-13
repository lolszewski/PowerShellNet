using System.Configuration;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Common.Interfaces;

namespace PowerShellNet.Common.Implementation
{
    public class PowerShellServicesLibraryConfigurationService : PowerShellServicesLibraryInstance, IPowerShellConfigurationService
    {
        public PowerShellServicesLibraryConfigurationService(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        public virtual T GetSettingOrDefault<T>(string appSettingName, T defaultValue)
        {
            var settingValueString = ConfigurationManager.AppSettings[appSettingName];
            if (!string.IsNullOrEmpty(settingValueString))
            {
                return (T)Instance.DataParsingService.GetValue(typeof(T), settingValueString);
            }

            return defaultValue;
        }
    }
}