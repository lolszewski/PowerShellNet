using System;
using System.Collections.Generic;

namespace PowerShellNet.ParrallelProcessing.Interfaces
{
    public interface IParallelProcessingService
    {
        IEnumerable<TResult> Process<TResult, TInput>(Func<IEnumerable<TInput>, IEnumerable<object>, IEnumerable<TResult>> processingMethod, IEnumerable<TInput> data, IEnumerable<object> parameters=null);
    }
}
