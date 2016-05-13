using System.Collections.Generic;
using System.Linq;
using PowerShellNet.Common;
using Xunit;

namespace PowerShellNet.Tests.ParrallelProcessingTests
{
    public class DataAggregatingServiceTests
    {
        public static IEnumerable<object[]> TestingData => new[]
        {
            new object[] {1, new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}},
            new object[] {2, new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}},
            new object[] {3, new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}},
            new object[] {4, new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}},
            new object[] {5, new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}},
            new object[] {6, new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}},
            new object[] {7, new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}},
            new object[] {8, new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}},
            new object[] {9, new[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" } }
        };

        [Theory]
        [MemberData("TestingData")]
        public void ShouldBeAbleToAggregateStringArrayIntoGivenPackagesCount(int packagesCount, string[] data)
        {
            var dividedData = PowerShellNetServicesLibrary.Default.ParralelProcessingDataDividingService.DivideData(data, packagesCount).ToArray();
            var aggregatedData = PowerShellNetServicesLibrary.Default.ParralelProcessingDataAggregatingService.AggregateData(dividedData).ToArray();

            Assert.Equal(data.Length, aggregatedData.Length);

            for (var i = 0; i < data.Length; i++)
            {
                Assert.Equal(data[i], aggregatedData[i]);
            }
        }
    }
}
