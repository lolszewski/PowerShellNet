using System.Collections.Generic;
using PowerShellNet.Connection.Model;

namespace PowerShellNet.Query.Interfaces
{
    public interface IPowerShellQueryService
    {
        IEnumerable<T> ExecuteQuery<T>(string query, PowerShellConnectionInfo connectionInfo=null, object paramters=null);
    }
}