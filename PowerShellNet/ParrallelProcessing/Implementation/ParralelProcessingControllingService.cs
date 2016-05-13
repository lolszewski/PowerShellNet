using System;
using PowerShellNet.Common;
using PowerShellNet.ParrallelProcessing.Interfaces;

namespace PowerShellNet.ParrallelProcessing.Implementation
{
    public class ParralelProcessingControllingService : IParralelProcessingControllingService
    {
        public virtual int GetParallelThreadsCount()
        {
            return PowerShellNetServicesLibrary.Default.ConfigurationService.GetSettingOrDefault("PowerShellParallelProcessingThreadsCount", Environment.ProcessorCount);
        }

        public virtual int GetMinimumArrayItems()
        {
            return PowerShellNetServicesLibrary.Default.ConfigurationService.GetSettingOrDefault("PowerShellParallelProcessingMinimumArrayItems", 1000);
        }
    }
}