using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using PowerShellNet.Common;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Connection.Model;
using PowerShellNet.Query.Interfaces;

namespace PowerShellNet.Query.Implementation
{
    public class PowerShellQueryService : PowerShellServicesLibraryInstance, IPowerShellQueryService
    {
        public PowerShellQueryService(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        public virtual IEnumerable<T> ExecuteQuery<T>(string query, PowerShellConnectionInfo connectionInfo = null, object paramters = null)
        {
            IEnumerable<T> result;

            using (var pipeline = Instance.ConnectionService.GetOpenedPipline(connectionInfo))
            {
                var properQuery = Instance.QueryStringService.GetProperQueryString(query, paramters);

                var command = new Command(properQuery, true);
                AppendParameters(command, paramters);
                
                pipeline.Commands.Add(command);

                var data = pipeline.Invoke();
                var fieldsString = data[0].ToString();
                
                var fields = Instance.QueryResultParsingSyntaxService.RecognizeFields(fieldsString).ToArray();
                result = ProcessData<T>(data.Skip(1), new List<object> { fields });
            }

            return result;
        }

        private void AppendParameters(Command command, object parameters)
        {
            if (parameters == null)
            {
                return;
            }

            var queryParameters = Instance.QueryParametersService.GetParameters(parameters);
            foreach (var queryParameter in queryParameters)
            {
                command.Parameters.Add(queryParameter);
            }
        }

        private IEnumerable<TResult> ProcessData<TResult>(IEnumerable<PSObject> data, IEnumerable<object> parameters)
        {
            ICollection<TResult> result = new List<TResult>();
            var parametersArray = parameters.ToArray();
            var dataArray = data.ToArray();

            var fields = (string[])parametersArray[0];

            for (var i = 0; i < dataArray.Length; i++)
            {
                var dataParts = Instance.QueryResultParsingSyntaxService.RecognizeData(dataArray[i].ToString());
                var item = Instance.QueryResultParsingService.ParseData<TResult>(fields, dataParts);
                result.Add(item);
            }

            return result;
        }
    }
}