using System.Collections.Generic;

namespace PowerShellNet.Query.Interfaces
{
    public interface IPowerShellQueryResultParsingService
    {
        T ParseData<T>(IEnumerable<string> fields, IEnumerable<string> dataParts);
    }
}