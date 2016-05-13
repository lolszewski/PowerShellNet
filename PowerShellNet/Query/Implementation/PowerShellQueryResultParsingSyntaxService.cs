using System.Collections.Generic;
using PowerShellNet.Common;
using PowerShellNet.Common.Abstract;
using PowerShellNet.Query.Interfaces;

namespace PowerShellNet.Query.Implementation
{
    public class PowerShellQueryResultParsingSyntaxService : PowerShellServicesLibraryInstance, IPowerShellQueryResultParsingSyntaxService
    {
        public PowerShellQueryResultParsingSyntaxService(PowerShellNetServicesLibrary instance)
            : base(instance)
        {
        }

        public virtual IEnumerable<string> RecognizeFields(string fieldsRecordString)
        {
            var syntax = Instance.ResultSyntaxService.GetResultSyntax();

            var recognizedFields = Recognize(fieldsRecordString, syntax.FieldsStartingCharacter, syntax.FieldsEndingCharacter, syntax.FieldsSeparationCharacter);

            return recognizedFields;
        }

        public virtual IEnumerable<string> RecognizeData(string dataRecordString)
        {
            var syntax = Instance.ResultSyntaxService.GetResultSyntax();

            var recognizedData = Recognize(dataRecordString, syntax.DataStartingCharacter, syntax.DataEndingCharacter, syntax.FieldsSeparationCharacter);

            return recognizedData;
        }

        protected virtual IEnumerable<string> Recognize(string recordString, char startingCharacter, char endingCharacter, char separationCharacter)
        {
            var fields = new List<string>();

            if (string.IsNullOrEmpty(recordString))
            {
                return fields;
            }

            var currentField = string.Empty;
            var fieldsString = recordString;

            var keepReading = false;
            var gatherAndStopReading = false;

            for (var i = 0; i < fieldsString.Length; i++)
            {
                var currentCharacter = (char?)fieldsString[i];
                var previousCharacter = i > 0 ? (char?)fieldsString[i - 1] : null;
                var previousPreviousCharacter = i > 1 ? (char?)fieldsString[i - 2] : null;
                var nextCharacter = i < fieldsString.Length - 1 ? (char?)fieldsString[i + 1] : null;
                var nextNextCharacter = i < fieldsString.Length - 2 ? (char?)fieldsString[i + 2] : null;

                var timeToStartReading = TimeToStartReading(currentCharacter, previousCharacter, previousPreviousCharacter, startingCharacter, separationCharacter);
                var timeToEndReading = TimeToEndReading(currentCharacter, nextCharacter, nextNextCharacter, endingCharacter, separationCharacter);

                if (!keepReading && timeToStartReading)
                {
                    keepReading = true;
                }

                if (keepReading)
                {
                    currentField += currentCharacter;
                }

                if (keepReading && timeToEndReading)
                {
                    gatherAndStopReading = true;
                }

                if (gatherAndStopReading)
                {
                    fields.Add(currentField);

                    gatherAndStopReading = false;
                    keepReading = false;
                    currentField = string.Empty;
                }
            }

            return fields;
        }

        private bool TimeToStartReading(char? currentCharacter, char? previousCharacter, char? previousPreviousCharacter, char startingCharacter, char separationCharacter)
        {
            if (currentCharacter == null)
            {
                return false;
            }

            if (currentCharacter == startingCharacter)
            {
                return false;
            }

            if (previousCharacter == startingCharacter && (previousPreviousCharacter == null || previousPreviousCharacter == separationCharacter))
            {
                return true;
            }

            return false;
        }

        private bool TimeToEndReading(char? currentCharacter, char? nextCharacter, char? nextNextCharacter, char endingCharacter, char separationCharacter)
        {
            if (currentCharacter == null)
            {
                return false;
            }

            if (currentCharacter == endingCharacter)
            {
                return false;
            }

            if (nextCharacter == endingCharacter && (nextNextCharacter == null || nextNextCharacter == separationCharacter))
            {
                return true;
            }

            return false;
        }
    }
}