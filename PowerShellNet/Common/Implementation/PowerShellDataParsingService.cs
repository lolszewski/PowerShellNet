using System;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Common.Interfaces;

namespace PowerShellNet.Common.Implementation
{
    public class PowerShellDataParsingService : PowerShellServicesLibraryInstance, IPowerShellDataParsingService
    {
        public PowerShellDataParsingService(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        public object GetValue(Type propertyType, string stringValue)
        {
            switch (propertyType.Name)
            {
                case "Int32":
                    {
                        return int.Parse(stringValue);
                    }
                case "Int64":
                    {
                        return long.Parse(stringValue);
                    }
                case "Decimal":
                    {
                        return decimal.Parse(stringValue);
                    }
                case "Double":
                    {
                        return double.Parse(stringValue);
                    }
                case "DateTime":
                    {
                        return DateTime.Parse(stringValue);
                    }
                case "Char":
                    {
                        return char.Parse(stringValue);
                    }
                default:
                    {
                        return stringValue;
                    }
            }
        }
    }
}
