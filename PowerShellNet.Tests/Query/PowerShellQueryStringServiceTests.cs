using PowerShellNet.Common;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PowerShellNet.Tests.Query
{
    public class PowerShellQueryStringServiceTests
    {
        [Fact]
        public void ShouldGenerateProperParametersStringForGivenParamtersList()
        {
            var queryParameters = new { logName = "Application", recordsCount = 1000 };
            var queryParametersString = PowerShellNetServicesLibrary.Default.QueryStringService.GetParametersString(queryParameters);
            var expectedParametersString = "param($logName, $recordsCount);";

            Assert.AreEqual(expectedParametersString, queryParametersString);
        }

        [Fact]
        public void ShouldGenerateProperQueryStringForGivenQueryAndParameters()
        {
            var query = "(Get-EventLog $logName -Newest $recordsCount | select Index, Message);";
            var queryParameters = new { logName = "Application", recordsCount = 1000 };
            var queryString = PowerShellNetServicesLibrary.Default.QueryStringService.GetProperQueryString(query, queryParameters);
            var expectedQueryString = @"param($logName, $recordsCount);
(Get-EventLog $logName -Newest $recordsCount | select Index, Message);";

            Assert.AreEqual(expectedQueryString, queryString);
        }
    }
}