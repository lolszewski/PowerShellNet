using System.Collections.Generic;
using System.Linq;
using PowerShellNet.ParrallelProcessing.Interfaces;

namespace PowerShellNet.ParrallelProcessing.Implementation
{
    public class ParralelProcessingDataDividingService : IParralelProcessingDataDividingService
    {
        public IEnumerable<IEnumerable<T>> DivideData<T>(T[] dataToDivide, int packagesCount)
        {
            var dataCount = dataToDivide.Length;
            var onePackageItemsCount = dataCount / packagesCount;
            var lastPackageItemsCount = dataCount - (onePackageItemsCount * (packagesCount - 1));

            for (var i = 0; i < packagesCount; i++)
            {
                var isLastPackage = i == (packagesCount - 1);
                var currentPackageCount = isLastPackage ? lastPackageItemsCount : onePackageItemsCount;

                yield return dataToDivide.Skip(i * onePackageItemsCount).Take(currentPackageCount);
            }
        }
    }
}
