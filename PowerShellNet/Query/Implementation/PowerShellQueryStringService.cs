using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerShellNet.Common;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Query.Interfaces;

namespace PowerShellNet.Query.Implementation
{
    public class PowerShellQueryStringService : PowerShellServicesLibraryInstance, IPowerShellQueryStringService
    {
        public PowerShellQueryStringService(PowerShellNetServicesLibrary instance) : base(instance)
        {
        }

        public virtual string GetParametersString(object parameters)
        {
            var queryParametersStringBuilder = new StringBuilder();
            var propertiesNames = GetParametersNames(parameters);
            var parametersListString = string.Join(", ", propertiesNames);

            queryParametersStringBuilder.Append("param(");
            queryParametersStringBuilder.Append(parametersListString);
            queryParametersStringBuilder.Append(");");

            var queryParametersString = queryParametersStringBuilder.ToString();
            return queryParametersString;
        }

        public virtual string GetProperQueryString(string query, object parameters)
        {
            var queryString = query;

            if (parameters == null)
            {
                return queryString;
            }

            var parametersString = Instance.QueryStringService.GetParametersString(parameters);
            if (!QueryAlreadyContainsParametersString(query, parametersString))
            {
                queryString = $"{parametersString}{Environment.NewLine}{query}";
            }

            return queryString;
        }

        private IEnumerable<string> GetParametersNames(object parameters)
        {
            var typeOfData = parameters.GetType();
            var properties = typeOfData.GetProperties();

            return properties.Select(propertyInfo => $"${propertyInfo.Name}");
        }

        private bool QueryAlreadyContainsParametersString(string query, string parametersString)
        {
            var cleanedQueryString = query.Replace(" ", string.Empty);
            var cleanedParametersString = parametersString.Replace(" ", string.Empty);

            return cleanedQueryString.Contains(cleanedParametersString);
        }
    }
}
