using System.Security;
using PowerShellNet.Common;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Connection.Interfaces;

namespace PowerShellNet.Connection.Implementation
{
    public class PowerShellPasswordService : PowerShellServicesLibraryInstance, IPowerShellPasswordService
    {
        public PowerShellPasswordService(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        public virtual SecureString SecurePassword(string unsecuredPassword)
        {
            var result = new SecureString();

            foreach (var passwordChar in unsecuredPassword)
            {
                result.AppendChar(passwordChar);
            }

            return result;
        }
    }
}