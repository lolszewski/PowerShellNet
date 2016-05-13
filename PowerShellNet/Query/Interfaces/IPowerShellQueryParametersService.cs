using System.Collections.Generic;
using System.Management.Automation.Runspaces;

namespace PowerShellNet.Query.Interfaces
{
    public interface IPowerShellQueryParametersService
    {
        IEnumerable<CommandParameter> GetParameters(object parameters);
    }
}
