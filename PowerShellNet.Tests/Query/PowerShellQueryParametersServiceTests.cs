using System;
using System.Linq;
using PowerShellNet.Common;
using Xunit;

namespace PowerShellNet.Tests.Query
{
    public class PowerShellQueryParametersServiceTests
    {
        [Fact]
        public void ShouldBeAbleToGetQueryParametersFromObject()
        {
            var parameters = new
            {
                logName = "Application",
                rowsCount = 1452,
                someDecimalValue = 12.45M,
                someDoubleValue = 78.45,
                someDateValue = DateTime.Now
            };

            var powerShellParamters = PowerShellNetServicesLibrary.Default.QueryParametersService.GetParameters(parameters).ToArray();

            Assert.Equal(powerShellParamters.Length, 5);

            Assert.Equal(powerShellParamters[0].Name, "logName");
            Assert.Equal(powerShellParamters[1].Name, "rowsCount");
            Assert.Equal(powerShellParamters[2].Name, "someDecimalValue");
            Assert.Equal(powerShellParamters[3].Name, "someDoubleValue");
            Assert.Equal(powerShellParamters[4].Name, "someDateValue");

            Assert.Equal((string)powerShellParamters[0].Value, parameters.logName);
            Assert.Equal((int)powerShellParamters[1].Value, parameters.rowsCount);
            Assert.Equal((decimal)powerShellParamters[2].Value, parameters.someDecimalValue);
            Assert.Equal((double)powerShellParamters[3].Value, parameters.someDoubleValue);
            Assert.Equal((DateTime)powerShellParamters[4].Value, parameters.someDateValue);
        }
    }
}