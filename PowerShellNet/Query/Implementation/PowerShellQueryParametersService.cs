using System.Collections.Generic;
using System.Management.Automation.Runspaces;
using PowerShellNet.Common;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Query.Interfaces;

namespace PowerShellNet.Query.Implementation
{
    public class PowerShellQueryParametersService : PowerShellServicesLibraryInstance, IPowerShellQueryParametersService
    {
        public PowerShellQueryParametersService(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        public IEnumerable<CommandParameter> GetParameters(object parameters)
        {
            var typeOfData = parameters.GetType();
            var properties = typeOfData.GetProperties();

            foreach (var propertyInfo in properties)
            {
                var propertyName = propertyInfo.Name;
                var propertyValue = propertyInfo.GetValue(parameters, null);

                yield return new CommandParameter(propertyName, propertyValue);
            }
        }
    }
}
