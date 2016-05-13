using System.Management.Automation.Runspaces;
using PowerShellNet.Connection.Model;

namespace PowerShellNet.Connection.Interfaces
{
    public interface IPowerShellConnectionService
    {
        Pipeline GetOpenedPipline(PowerShellConnectionInfo connectionInfo);
    }
}