using System.Linq;
using PowerShellNet.Common;
using PowerShellNet.Connection.Model;
using Xunit;

namespace PowerShellNet.Tests.Query
{
    public class PowerShellQueryServiceTests
    {
        public class ResultData
        {
            public int Index { get; set; }

            public string Message { get; set; }
        }

        [Theory]
        [InlineData(30, "Application", "localhost", @"myLogin", "myPassword", null)]
        [InlineData(30, "System", "localhost", @"myLogin", "myPassword", null)]
        [InlineData(1000, "Application", "localhost", @"myLogin", "myPassword", null)]
        public void ShouldBeAbleToDownloadNewestEventLogRecordsForGivenLogNameAndRecordsCountForLocalhost(int recordsCount, string eventLogName, string machineNameOrAddress, string userName, string password, string port)
        {
            var connectionInfo = new PowerShellConnectionInfo { MachineNameOrAddress = machineNameOrAddress, UserName = userName, Password = password };
            var query = @"
            $result = (Get-EventLog " + eventLogName + @" -Newest " + recordsCount + @" | select Index, Message);
            
            ""{Index},{Message}"";
            for ($i = 0; $i -lt $result.Length; $i++)
            {
                $endingChar = """";
                if ($i -lt $result.Length - 1)
                {
                    $endingChar = "","";
                }

                '{' + [string]$result[$i].Index + '},' + '{' + $result[$i].Message + '}';
            }
                        ";

            var records = PowerShellNetServicesLibrary.Default.QueryService.ExecuteQuery<ResultData>(query, connectionInfo);
            
            Assert.NotEqual(0, records.Count());
        }

        [Theory]
        [InlineData(30, "Application", "localhost", @"myLogin", "myPassword", null)]
        [InlineData(30, "System", "localhost", @"myLogin", "myPassword", null)]
        [InlineData(1000, "Application", "localhost", @"myLogin", "myPassword", null)]
        public void ShouldBeAbleToDownloadNewestEventLogRecordsForGivenLogNameAndRecordsCountForLocalhostWithParameters(int recordsCount, string eventLogName, string machineNameOrAddress, string userName, string password, string port)
        {
            var connectionInfo = new PowerShellConnectionInfo { MachineNameOrAddress = machineNameOrAddress, UserName = userName, Password = password };
            var queryParameters = new { logName = eventLogName, recordsCount };

            var query = @"
            $result = (Get-EventLog $logName -Newest $recordsCount | select Index, Message);
            
            '{Index},{Message}';
            for ($i = 0; $i -lt $result.Length; $i++)
            {
                $endingChar = '';
                if ($i -lt $result.Length - 1)
                {
                    $endingChar = ',';
                }

                '{' + [string]$result[$i].Index + '},' + '{' + $result[$i].Message + '}';
            }";

            var records = PowerShellNetServicesLibrary.Default.QueryService.ExecuteQuery<ResultData>(query, connectionInfo, queryParameters);

            Assert.NotEqual(0, records.Count());
        }

        [Theory]
        [InlineData(30, "Application", "localhost", @"myLogin", "myPassword", null)]
        [InlineData(30, "System", "localhost", @"myLogin", "myPassword", null)]
        [InlineData(1000, "Application", "localhost", @"myLogin", "myPassword", null)]
        public void ShouldBeAbleToDownloadNewestEventLogRecordsForGivenLogNameAndRecordsCountForLocalhostWithQueryBuilding(int recordsCount, string eventLogName, string machineNameOrAddress, string userName, string password, string port)
        {
            var connectionInfo = new PowerShellConnectionInfo { MachineNameOrAddress = machineNameOrAddress, UserName = userName, Password = password };
            var queryParameters = new { logName = eventLogName, recordsCount };
            var query = @"(Get-EventLog $logName -Newest $recordsCount | select Index, Message);";

            var records = PowerShellNetServicesLibrary.Default.QueryService.ExecuteQuery<ResultData>(query, connectionInfo, queryParameters);

            Assert.NotEqual(0, records.Count());
        }

        [Theory]
        [InlineData(30, "Application", "localhost", @"myLogin", "myPassword", null)]
        [InlineData(30, "System", "localhost", @"myLogin", "myPassword", null)]
        [InlineData(1000, "Application", "localhost", @"myLogin", "myPassword", null)]
        public void ShouldBeAbleToDownloadNewestEventLogRecordsForGivenLogNameAndRecordsCountForLocalhostWithQueryBuildingAndParametersStringInQuery(int recordsCount, string eventLogName, string machineNameOrAddress, string userName, string password, string port)
        {
            var connectionInfo = new PowerShellConnectionInfo { MachineNameOrAddress = machineNameOrAddress, UserName = userName, Password = password };
            var queryParameters = new { logName = eventLogName, recordsCount };
            var query = @"param($logName, $recordsCount);
(Get-EventLog $logName -Newest $recordsCount | select Index, Message);";

            var records = PowerShellNetServicesLibrary.Default.QueryService.ExecuteQuery<ResultData>(query, connectionInfo, queryParameters);

            Assert.NotEqual(0, records.Count());
        }

        [Theory]
        [InlineData(30, "Application")]
        [InlineData(30, "System")]
        [InlineData(1000, "Application")]
        public void ShouldBeAbleToDownloadNewestEventLogRecordsForGivenLogNameAndRecordsCountForLocalhostWithQueryBuildingAndParametersStringInQueryWithNullConnection(int recordsCount, string eventLogName)
        {
            var queryParameters = new { logName = eventLogName, recordsCount };
            var query = @"param($logName, $recordsCount);
(Get-EventLog $logName -Newest $recordsCount | select Index, Message);";

            var records = PowerShellNetServicesLibrary.Default.QueryService.ExecuteQuery<ResultData>(query, null, queryParameters);

            Assert.NotEqual(0, records.Count());
        }
    }
}