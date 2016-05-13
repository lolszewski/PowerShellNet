namespace PowerShellNet.Common.Abstract
{
    public abstract class PowerShellServicesLibraryInstance
    {
        protected PowerShellNetServicesLibrary Instance { get; }

        protected PowerShellServicesLibraryInstance(PowerShellNetServicesLibrary instance)
        {
            Instance = instance;
        }

        public string GetInstanceId()
        {
            return Instance.InstanceId;
        }
    }
}