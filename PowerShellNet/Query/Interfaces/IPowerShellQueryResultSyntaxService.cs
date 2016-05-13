using PowerShellNet.Connection.Model;

namespace PowerShellNet.Query.Interfaces
{
    public interface IPowerShellQueryResultSyntaxService
    {
        char GetFieldsStartingCharacter();

        char GetFieldsEndingCharacter();

        char GetFieldsSeparationCharacter();

        char GetDataStartingCharacter();
                
        char GetDataEndingCharacter();
                
        char GetDataSeparationCharacter();

        PowerShellResultSyntax GetResultSyntax();
    }
}
