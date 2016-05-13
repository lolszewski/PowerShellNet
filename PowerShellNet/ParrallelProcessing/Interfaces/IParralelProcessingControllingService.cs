namespace PowerShellNet.ParrallelProcessing.Interfaces
{
    public interface IParralelProcessingControllingService
    {
        int GetParallelThreadsCount();

        int GetMinimumArrayItems();
    }
}
