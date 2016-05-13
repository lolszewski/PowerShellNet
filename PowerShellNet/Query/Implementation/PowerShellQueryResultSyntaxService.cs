using PowerShellNet.Common;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Connection.Model;
using PowerShellNet.Query.Interfaces;

namespace PowerShellNet.Query.Implementation
{
    public class PowerShellQueryResultSyntaxService : PowerShellServicesLibraryInstance, IPowerShellQueryResultSyntaxService
    {
        public PowerShellQueryResultSyntaxService(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        public virtual char GetFieldsStartingCharacter()
        {
            return Instance.ConfigurationService.GetSettingOrDefault("PowerShellFieldsStartingCharacter", '{'); ;
        }

        public virtual char GetFieldsEndingCharacter()
        {
            return Instance.ConfigurationService.GetSettingOrDefault("PowerShellFieldsEndingCharacter", '}');
        }

        public virtual char GetFieldsSeparationCharacter()
        {
            return Instance.ConfigurationService.GetSettingOrDefault("PowerShellFieldsSeparationCharacter", ',');
        }

        public virtual char GetDataStartingCharacter()
        {
            return Instance.ConfigurationService.GetSettingOrDefault("PowerShellDataStartingCharacter", '{');
        }

        public virtual char GetDataEndingCharacter()
        {
            return Instance.ConfigurationService.GetSettingOrDefault("PowerShellDataEndingCharacter", '}');
        }

        public virtual char GetDataSeparationCharacter()
        {
            return Instance.ConfigurationService.GetSettingOrDefault("PowerShellDataSeparationCharacter", ',');
        }

        public virtual PowerShellResultSyntax GetResultSyntax()
        {
            var syntax = new PowerShellResultSyntax
            {
                FieldsStartingCharacter = GetFieldsStartingCharacter(),
                FieldsEndingCharacter = GetFieldsEndingCharacter(),
                FieldsSeparationCharacter = GetFieldsSeparationCharacter(),
                DataStartingCharacter = GetDataStartingCharacter(),
                DataEndingCharacter = GetDataEndingCharacter(),
                DataSeparationCharacter = GetDataSeparationCharacter()
            };

            return syntax;
        }
    }
}
