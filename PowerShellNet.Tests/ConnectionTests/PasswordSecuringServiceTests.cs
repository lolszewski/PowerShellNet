using System;
using System.Runtime.InteropServices;
using System.Security;
using PowerShellNet.Common;
using Xunit;

namespace PowerShellNet.Tests.ConnectionTests
{
    public class PasswordSecuringServiceTests
    {
        [Theory]
        [InlineData("passwordToSecure")]
        [InlineData("@#$%^$&#$*$&ERGDFVQazadwste4   532841y0234123850hfsaddh onfhwfr w")]
        [InlineData(":PO>?POUO4584423z.xc,.;/eq1]312-=';asd,as!@$SDNYUsdfqweq")]
        [InlineData("\"\\sd\"eqweqwqwfsd\"\"ewrer#@#$@FGhreqczsrq'wr'qwqasdasec")]
        public void ShouldSecurePasswordToBeAbleForProperMarshalDecryption(string unsecuredPassword)
        {
            var encryptedPassword = PowerShellNetServicesLibrary.Default.PasswordService.SecurePassword(unsecuredPassword);
            var decryptedPassword = DecryptSecuredString(encryptedPassword);

            Assert.Equal(unsecuredPassword, decryptedPassword);
        }

        private static string DecryptSecuredString(SecureString securedString)
        {
            var valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(securedString);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
