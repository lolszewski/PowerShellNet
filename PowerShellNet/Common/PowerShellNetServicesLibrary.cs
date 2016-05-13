using System;
using PowerShellNet.Common.Implementation;
using PowerShellNet.Common.Interfaces;
using PowerShellNet.Connection.Implementation;
using PowerShellNet.Connection.Interfaces;
using PowerShellNet.Query.Implementation;
using PowerShellNet.Query.Interfaces;

namespace PowerShellNet.Common
{
    public class PowerShellNetServicesLibrary
    {
        private static PowerShellNetServicesLibrary _instance;

        public static PowerShellNetServicesLibrary Default => _instance ?? (_instance = GetLibrary());

        public string InstanceId { get; private set; }

        public IPowerShellConfigurationService ConfigurationService { get; set; }
  
        public IPowerShellConnectionService ConnectionService { get; set; }

        public IPowerShellDataParsingService DataParsingService { get; set; }

        public IPowerShellPasswordService PasswordService { get; set; }

        public IPowerShellQueryService QueryService { get; set; }

        public IPowerShellQueryResultParsingSyntaxService QueryResultParsingSyntaxService { get; set; }

        public IPowerShellQueryResultParsingService QueryResultParsingService { get; set; }

        public IPowerShellQueryResultSyntaxService ResultSyntaxService { get; set; }

        public IPowerShellQueryParametersService QueryParametersService { get; set; }

        public IPowerShellQueryStringService QueryStringService { get; set; }

        private PowerShellNetServicesLibrary()
        {
            PasswordService = new PowerShellPasswordService(this);
            ConnectionService = new PowerShellConnectionService(this);
            QueryResultParsingSyntaxService = new PowerShellQueryResultParsingSyntaxService(this);
            ResultSyntaxService = new PowerShellQueryResultSyntaxService(this);
            QueryResultParsingService = new PowerShellQueryResultParsingService(this);
            QueryService = new PowerShellQueryService(this);
            DataParsingService = new PowerShellDataParsingService(this);
            ConfigurationService = new PowerShellServicesLibraryConfigurationService(this);
            QueryParametersService = new PowerShellQueryParametersService(this);
            QueryStringService = new PowerShellQueryStringService(this);

            InstanceId = Guid.NewGuid().ToString();
        }

        public static PowerShellNetServicesLibrary GetLibrary()
        {
            return new PowerShellNetServicesLibrary();
        }
    }
}