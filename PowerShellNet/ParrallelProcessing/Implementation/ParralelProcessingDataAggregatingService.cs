using System.Collections.Generic;
using System.Linq;
using PowerShellNet.ParrallelProcessing.Interfaces;

namespace PowerShellNet.ParrallelProcessing.Implementation
{
    public class ParralelProcessingDataAggregatingService : IParralelProcessingDataAggregatingService
    {
        public virtual IEnumerable<T> AggregateData<T>(IEnumerable<IEnumerable<T>> dividedData)
        {
            return dividedData.SelectMany(dataPackage => dataPackage.ToArray());
        }
    }
}
