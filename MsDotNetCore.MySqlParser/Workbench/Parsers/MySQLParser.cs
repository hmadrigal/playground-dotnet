using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Workbench.Parsers
{
    public partial class MySQLParser : MySQLBaseRecognizer
    {
        public MySQLParser(ITokenStream input, IMySQLRecognizerCommon mySQLRecognizerCommon) : this(input)
        {
            this.mySQLRecognizerCommon = mySQLRecognizerCommon;
        }

        public MySQLParser(ITokenStream input, TextWriter output, TextWriter errorOutput, IMySQLRecognizerCommon mySQLRecognizerCommon)
        : this(input, output, errorOutput)
        {
            this.mySQLRecognizerCommon = mySQLRecognizerCommon;
        }
    }
}
