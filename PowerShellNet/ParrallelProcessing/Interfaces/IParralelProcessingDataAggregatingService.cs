using System.Collections.Generic;

namespace PowerShellNet.ParrallelProcessing.Interfaces
{
    public interface IParralelProcessingDataAggregatingService
    {
        IEnumerable<T> AggregateData<T>(IEnumerable<IEnumerable<T>> dividedData);
    }
}