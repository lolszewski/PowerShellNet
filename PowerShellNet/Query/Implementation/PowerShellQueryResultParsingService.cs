using System;
using System.Collections.Generic;
using System.Linq;
using PowerShellNet.Common;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Query.Interfaces;

namespace PowerShellNet.Query.Implementation
{
    public class PowerShellQueryResultParsingService : PowerShellServicesLibraryInstance, IPowerShellQueryResultParsingService
    {
        public PowerShellQueryResultParsingService(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        public virtual T ParseData<T>(IEnumerable<string> fields, IEnumerable<string> dataParts)
        {
            var typeOfData = typeof (T);
            var instance = (T)Activator.CreateInstance(typeOfData);
            var fieldsArray = fields.ToArray();
            var dataPartsArray = dataParts.ToArray();

            var properties = typeOfData.GetProperties();
            for (var i = 0; i < fieldsArray.Length; i++)
            {
                var property = properties.First(p => p.Name == fieldsArray[i]);
                var propertyValue = Instance.DataParsingService.GetValue(property.PropertyType, dataPartsArray[i]);

                property.SetValue(instance, propertyValue);
            }

            return instance;
        }
    }
}
