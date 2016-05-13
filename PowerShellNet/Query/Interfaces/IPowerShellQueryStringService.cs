namespace PowerShellNet.Query.Interfaces
{
    public interface IPowerShellQueryStringService
    {
        string GetParametersString(object parameters);

        string GetProperQueryString(string query, object parameters);
    }
}
