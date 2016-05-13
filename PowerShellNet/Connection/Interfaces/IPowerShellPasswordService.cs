using System.Security;

namespace PowerShellNet.Connection.Interfaces
{
    public interface IPowerShellPasswordService
    {
        SecureString SecurePassword(string unsecuredPassword);
    }
}
