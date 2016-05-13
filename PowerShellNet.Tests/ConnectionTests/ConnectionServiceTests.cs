using Xunit;
using System.Management.Automation.Runspaces;
using PowerShellNet.Common;
using PowerShellNet.Connection.Model;

namespace PowerShellNet.Tests.ConnectionTests
{
    public class ConnectionServiceTests
    {
        [Theory]
        [InlineData("localhost", @"domain\username", "password", null)]
        [InlineData(null, null, null, null)]
        [InlineData("localhost", null, null, null)]
        [InlineData(null, @"domain\username", null, null)]
        [InlineData(null, @"domain\username", "password", null)]
        public void ShouldBeAbleToReturnOpenedRunspaceToLocalhostForGivenParameters(string machineNameOrAddress, string userName, string password, string port)
        {
            var connectionInfo = new PowerShellConnectionInfo { MachineNameOrAddress = machineNameOrAddress, UserName = userName, Password = password };
            var pipeline = PowerShellNetServicesLibrary.Default.ConnectionService.GetOpenedPipline(connectionInfo);

            Assert.Equal(pipeline.Runspace.RunspaceStateInfo.State, RunspaceState.Opened);
        }
    }
}