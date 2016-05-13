using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerShellNet.Common;
using PowerShellNet.ParrallelProcessing.Interfaces;

namespace PowerShellNet.ParrallelProcessing.Implementation
{
    public class ParallelProcessingService : IParallelProcessingService
    {
        public virtual IEnumerable<TResult> Process<TResult, TInput>(Func<IEnumerable<TInput>, IEnumerable<object>, IEnumerable<TResult>> processingMethod, IEnumerable<TInput> data, IEnumerable<object> parameters)
        {
            var packagesCount = PowerShellNetServicesLibrary.Default.ParralelProcessingControllingService.GetParallelThreadsCount();
            var dataPackages = PowerShellNetServicesLibrary.Default.ParralelProcessingDataDividingService.DivideData(data.ToArray(), packagesCount).ToArray();

            var parallelResult = new List<List<TResult>>();
            
            Parallel.ForEach(dataPackages, dataPackage =>
            {
                var dataPackageArray = dataPackage.ToArray();
                var packageResult = processingMethod(dataPackageArray, parameters).ToList();

                parallelResult.Add(packageResult);
            });

            var aggregatedResult = new List<TResult>();
            foreach (var parallelSingleRresult in parallelResult)
            {
                aggregatedResult.AddRange(parallelSingleRresult);
            }

            return aggregatedResult;
        }
    }
}
