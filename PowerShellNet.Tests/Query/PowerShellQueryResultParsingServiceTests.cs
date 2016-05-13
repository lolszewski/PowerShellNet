using System;
using System.Linq;
using PowerShellNet.Common;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PowerShellNet.Tests.Query
{
    public class PowerShellQueryResultParsingServiceTests
    {
        public class ResultData
        {
            public int Index { get; set; }

            public string Message { get; set; }
        }

        public class ResultDataWithDateTime
        {
            public int Index { get; set; }

            public string Message { get; set; }

            public DateTime Time { get; set; }
        }

        public class ResultDataWithDecimal
        {
            public int Index { get; set; }

            public string Message { get; set; }

            public decimal DecimalValue { get; set; }
        }

        public class ResultDataWithDouble
        {
            public int Index { get; set; }

            public string Message { get; set; }

            public double DoubleValue { get; set; }
        }

        public class ResultDataWithLong
        {
            public int Index { get; set; }

            public string Message { get; set; }

            public long LongValue { get; set; }
        }

        [Theory]
        [InlineData("{Index},{Message}", "{154263},{Data part}")]
        [InlineData("{Index},{Message}", "{1},{Data part ex 2}")]
        [InlineData("{Index},{Message}", "{80000},{Data part ex 3}")]
        public void ShouldBeAbleToParseResultForResultDataClass(string fieldsString, string dataString)
        {
            var fields = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeFields(fieldsString).ToArray();
            var data = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeData(dataString).ToArray();
            var resultData = PowerShellNetServicesLibrary.Default.QueryResultParsingService.ParseData<ResultData>(fields, data);

            Assert.AreEqual(resultData.Index.ToString(), data[0]);
            Assert.AreEqual(resultData.Message, data[1]);
        }

        [Theory]
        [InlineData("{Index},{Message},{Time}", "{154263},{Data part},{2015-10-11 15:00:00}")]
        [InlineData("{Index},{Message},{Time}", "{1},{Data part ex 2},{2015-10-11 15:00:00}")]
        [InlineData("{Index},{Message},{Time}", "{80000},{Data part ex 3},{2015-10-11 15:00:00}")]
        [InlineData("{Index},{Message},{Time}", "{80000},{Data part ex 3},{10/11/2015 10:00:00 AM}")]
        public void ShouldBeAbleToParseResultForResultDataWithDateTimeClass(string fieldsString, string dataString)
        {
            var fields = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeFields(fieldsString).ToArray();
            var data = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeData(dataString).ToArray();
            var resultData = PowerShellNetServicesLibrary.Default.QueryResultParsingService.ParseData<ResultDataWithDateTime>(fields, data);

            Assert.AreEqual(resultData.Index.ToString(), data[0]);
            Assert.AreEqual(resultData.Message, data[1]);
            Assert.AreEqual(resultData.Time, DateTime.Parse(data[2]));
        }

        [Theory]
        [InlineData("{Index},{Message},{DecimalValue}", "{154263},{Data part},{14.15}")]
        [InlineData("{Index},{Message},{DecimalValue}", "{1},{Data part ex 2},{8456.784}")]
        [InlineData("{Index},{Message},{DecimalValue}", "{1},{Data part ex 2},{-8456.784}")]
        [InlineData("{Index},{Message},{DecimalValue}", "{80000},{Data part ex 3},{13212154.6325}")]
        public void ShouldBeAbleToParseResultForResultDataWithDecimalClass(string fieldsString, string dataString)
        {
            var fields = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeFields(fieldsString).ToArray();
            var data = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeData(dataString).ToArray();
            var resultData = PowerShellNetServicesLibrary.Default.QueryResultParsingService.ParseData<ResultDataWithDecimal>(fields, data);

            Assert.AreEqual(resultData.Index.ToString(), data[0]);
            Assert.AreEqual(resultData.Message, data[1]);
            Assert.AreEqual(resultData.DecimalValue, decimal.Parse(data[2]));
        }

        [Theory]
        [InlineData("{Index},{Message},{DoubleValue}", "{154263},{Data part},{14.15}")]
        [InlineData("{Index},{Message},{DoubleValue}", "{1},{Data part ex 2},{8456.784}")]
        [InlineData("{Index},{Message},{DoubleValue}", "{1},{Data part ex 2},{-8456.784}")]
        [InlineData("{Index},{Message},{DoubleValue}", "{80000},{Data part ex 3},{13212154.6325}")]
        public void ShouldBeAbleToParseResultForResultDataWithDoubleClass(string fieldsString, string dataString)
        {
            var fields = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeFields(fieldsString).ToArray();
            var data = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeData(dataString).ToArray();
            var resultData = PowerShellNetServicesLibrary.Default.QueryResultParsingService.ParseData<ResultDataWithDouble>(fields, data);

            Assert.AreEqual(resultData.Index.ToString(), data[0]);
            Assert.AreEqual(resultData.Message, data[1]);
            Assert.AreEqual(resultData.DoubleValue, double.Parse(data[2]));
        }

        [Theory]
        [InlineData("{Index},{Message},{LongValue}", "{154263},{Data part},{1487455622}")]
        [InlineData("{Index},{Message},{LongValue}", "{1},{Data part ex 2},{14874585497}")]
        [InlineData("{Index},{Message},{LongValue}", "{80000},{Data part ex 3},{-148712345}")]
        public void ShouldBeAbleToParseResultForResultDataWithLongClass(string fieldsString, string dataString)
        {
            var fields = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeFields(fieldsString).ToArray();
            var data = PowerShellNetServicesLibrary.Default.QueryResultParsingSyntaxService.RecognizeData(dataString).ToArray();
            var resultData = PowerShellNetServicesLibrary.Default.QueryResultParsingService.ParseData<ResultDataWithLong>(fields, data);

            Assert.AreEqual(resultData.Index.ToString(), data[0]);
            Assert.AreEqual(resultData.Message, data[1]);
            Assert.AreEqual(resultData.LongValue, long.Parse(data[2]));
        }
    }
}