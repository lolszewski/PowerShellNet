using PowerShellNet.Common;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Connection.Model;
using PowerShellNet.Query.Implementation;
using PowerShellNet.Query.Interfaces;
using Xunit;

namespace PowerShellNet.Tests.ServicesLibaryTests
{
    public class PowerShellQueryResultSyntaxService2 : PowerShellServicesLibraryInstance, IPowerShellQueryResultSyntaxService
    {
        public PowerShellQueryResultSyntaxService2(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        public char GetFieldsStartingCharacter()
        {
            return '$';
        }

        public char GetFieldsEndingCharacter()
        {
            throw new System.NotImplementedException();
        }

        public char GetFieldsSeparationCharacter()
        {
            throw new System.NotImplementedException();
        }

        public char GetDataStartingCharacter()
        {
            throw new System.NotImplementedException();
        }

        public char GetDataEndingCharacter()
        {
            throw new System.NotImplementedException();
        }

        public char GetDataSeparationCharacter()
        {
            throw new System.NotImplementedException();
        }

        public PowerShellResultSyntax GetResultSyntax()
        {
            throw new System.NotImplementedException();
        }
    }

    public class PowerShellServicesLibraryInstanceTests
    {
        [Fact]
        public void ShouldReturnDifferentServicesLibraryInstance()
        {
            var instance = PowerShellNetServicesLibrary.GetLibrary();
            var expectedInstanceId = instance.InstanceId;

            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.ConfigurationService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.ConnectionService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.DataParsingService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.PasswordService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryParametersService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryResultParsingService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryResultParsingSyntaxService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryStringService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.ResultSyntaxService as PowerShellServicesLibraryInstance));

            var notExpectedInstanceId = PowerShellNetServicesLibrary.Default.InstanceId;

            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.ConfigurationService as PowerShellServicesLibraryInstance));
            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.ConnectionService as PowerShellServicesLibraryInstance));
            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.DataParsingService as PowerShellServicesLibraryInstance));
            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.PasswordService as PowerShellServicesLibraryInstance));
            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.QueryParametersService as PowerShellServicesLibraryInstance));
            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.QueryResultParsingService as PowerShellServicesLibraryInstance));
            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.QueryResultParsingSyntaxService as PowerShellServicesLibraryInstance));
            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.QueryService as PowerShellServicesLibraryInstance));
            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.QueryStringService as PowerShellServicesLibraryInstance));
            Assert.NotEqual(notExpectedInstanceId, GetServiceInstanceId(instance.ResultSyntaxService as PowerShellServicesLibraryInstance));
        }

        [Fact]
        public void ShouldBeAbleToInjectDifferentServiceImplementationWithInstanceConsistency()
        {
            var instance = PowerShellNetServicesLibrary.GetLibrary();
            instance.ResultSyntaxService = new PowerShellQueryResultSyntaxService2(instance);

            var expectedInstanceId = instance.InstanceId;

            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.ConfigurationService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.ConnectionService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.DataParsingService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.PasswordService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryParametersService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryResultParsingService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryResultParsingSyntaxService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.QueryStringService as PowerShellServicesLibraryInstance));
            Assert.Equal(expectedInstanceId, GetServiceInstanceId(instance.ResultSyntaxService as PowerShellServicesLibraryInstance));
        }

        [Fact]
        public void ShouldBeAbleToInjectDifferentServiceImplementationProperly()
        {
            var instance = PowerShellNetServicesLibrary.GetLibrary();
            var notExpectedSyntaxValue = instance.ResultSyntaxService.GetFieldsStartingCharacter();

            instance.ResultSyntaxService = new PowerShellQueryResultSyntaxService2(instance);
            var syntaxtValue = instance.ResultSyntaxService.GetFieldsStartingCharacter();

            Assert.NotEqual(notExpectedSyntaxValue, syntaxtValue);
        }

        private string GetServiceInstanceId(PowerShellServicesLibraryInstance serviceInstance)
        {
            return serviceInstance.GetInstanceId();
        }
    }
}
