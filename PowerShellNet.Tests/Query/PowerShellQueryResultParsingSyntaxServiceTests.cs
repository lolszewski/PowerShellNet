using System.Collections.Generic;
using System.Linq;
using PowerShellNet.Common;
using Xunit;

namespace PowerShellNet.Tests.Query
{
    public class PowerShellQueryResultParsingSyntaxServiceTests
    {
        [Theory]
        [InlineData("{1Index},{Message}")]
        [InlineData("{2In{something inside}dex},{Message}")]
        [InlineData("{3In{something {something inside},{ inside}dex},{Messa{,},{}}}ge}")]
        [InlineData("{4In{something {something inside},{ inside}dex},{Messa{,},{}}}ge},{ inside}dex},{Messa{,},{}}}geLongName1},{ inside}dex},{Messa{,},{}}}geLongName2},{ inside}dex},{Messa{,},{}}}geLongName3},{ inside}dex},{Messa{,},{}}}geLongName4},{ inside}dex},{Messa{,},{}}}geLongName4},{ inside}dex},{Messa{,},{}}}geLongName5},{ inside}dex},{Messa{,},{}}}geLongName6},{ inside}dex},{Messa{,},{}}}geLongName7},{ inside}dex},{Messa{,},{}}}geLongName8}")]
        public void ShouldBeAbleToRecognizeFields(string fieldsString)
        {
            IEnumerable<string> fields = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeFields(fieldsString);

            var fieldsArray = fields as string[] ?? fields.ToArray();
            Assert.NotEqual(fieldsArray.ToArray().Length, 1);

            foreach (var field in fieldsArray)
            {
                Assert.Equal(true, fieldsString.Contains($"{"{"}{field}{"}"}"));
            }
        }

        [Theory]
        [InlineData("{This is some very fancy data part},{And this one is second data part},{80000},{This is also something}")]
        [InlineData("{This is some very fancy data part},{80000}")]
        [InlineData("{This is some \"soething in quotes\"very fancy data part},{80000}")]
        public void ShouldBeAbleToRecognizeData(string dataString)
        {
            IEnumerable<string> dataParts = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeData(dataString);

            var dataPartsArray = dataParts as string[] ?? dataParts.ToArray();
            Assert.NotEqual(dataPartsArray.ToArray().Length, 1);

            foreach (var dataPart in dataPartsArray)
            {
                Assert.Equal(true, dataString.Contains($"{"{"}{dataPart}{"}"}"));
            }
        }
    }
}