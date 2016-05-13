using System.Collections.Generic;

namespace PowerShellNet.Query.Interfaces
{
    public interface IPowerShellQueryResultParsingSyntaxService
    {
        IEnumerable<string> RecognizeFields(string fieldsRecordString);

        IEnumerable<string> RecognizeData(string dataRecordString);
    } 
}
