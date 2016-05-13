using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellNet.Connection.Model
{
    public class PowerShellResultSyntax
    {
        public char FieldsStartingCharacter { get; set; }

        public char FieldsEndingCharacter { get; set; }

        public char FieldsSeparationCharacter { get; set; }
        
        public char DataStartingCharacter { get; set; }
        
        public char DataEndingCharacter { get; set; }
        
        public char DataSeparationCharacter { get; set; }
    }
}
