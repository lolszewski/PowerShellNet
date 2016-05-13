using System;

namespace PowerShellNet.Common.Interfaces
{
    public interface IPowerShellDataParsingService
    {
        object GetValue(Type propertyType, string stringValue);
    }
}
