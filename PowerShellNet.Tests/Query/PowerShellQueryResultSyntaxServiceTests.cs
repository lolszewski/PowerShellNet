using PowerShellNet.Common;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PowerShellNet.Tests.Query
{
    public class PowerShellQueryResultSyntaxServiceTests
    {
        [Fact]
        public void ShouldBeAbleToGetPowerShellSyntaxObject()
        {
            var syntax = PowerShellNetServicesLibrary.Default.ResultSyntaxService.GetResultSyntax();

            Assert.AreNotEqual(syntax.FieldsStartingCharacter, null);
            Assert.AreNotEqual(syntax.FieldsEndingCharacter, null);
            Assert.AreNotEqual(syntax.FieldsSeparationCharacter, null);
            Assert.AreNotEqual(syntax.DataStartingCharacter, null);
            Assert.AreNotEqual(syntax.DataEndingCharacter, null);
            Assert.AreNotEqual(syntax.DataSeparationCharacter, null);
        }
    }
}