using System.Collections.Generic;

namespace PowerShellNet.ParrallelProcessing.Interfaces
{
    public interface IParralelProcessingDataDividingService
    {
        IEnumerable<IEnumerable<T>> DivideData<T>(T[] dataToDivide, int packagesCount);
    }
}