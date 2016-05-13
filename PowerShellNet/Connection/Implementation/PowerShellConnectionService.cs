using System.Management.Automation;
using System.Management.Automation.Runspaces;
using PowerShellNet.Common;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Connection.Interfaces;
using PowerShellNet.Connection.Model;

namespace PowerShellNet.Connection.Implementation
{
    public class PowerShellConnectionService : PowerShellServicesLibraryInstance, IPowerShellConnectionService
    {
        public PowerShellConnectionService(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        protected const string ShellUrl = "http://schemas.microsoft.com/powershell/Microsoft.PowerShell";

        protected const string DefaultPowershellListenerPort = "5985";

        public virtual Pipeline GetOpenedPipline(PowerShellConnectionInfo connectionInfo)
        {
            var runspace = RunspaceFactory.CreateRunspace();

            if (!IsLocalhostConnection(connectionInfo))
            {
                connectionInfo.Port = connectionInfo.Port ?? DefaultPowershellListenerPort;

                var securedPassword = Instance.PasswordService.SecurePassword(connectionInfo.Password);
                var credential = new PSCredential(connectionInfo.UserName, securedPassword);
                var listernerPort = int.Parse(connectionInfo.Port);

                var connection = new WSManConnectionInfo(false, connectionInfo.MachineNameOrAddress, listernerPort, "/wsman", ShellUrl, credential);

                runspace = RunspaceFactory.CreateRunspace(connection);
            }

            runspace.Open();

            var pipeline = runspace.CreatePipeline();
            return pipeline;
        }

        protected virtual bool IsLocalhostConnection(PowerShellConnectionInfo connectionInfo)
        {
            var isLocalHost =
                connectionInfo == null ||
                connectionInfo.MachineNameOrAddress == "localhost" ||
                string.IsNullOrEmpty(connectionInfo.MachineNameOrAddress) ||
                string.IsNullOrEmpty(connectionInfo.UserName) ||
                string.IsNullOrEmpty(connectionInfo.Password);

            return isLocalHost;
        }
    }
}