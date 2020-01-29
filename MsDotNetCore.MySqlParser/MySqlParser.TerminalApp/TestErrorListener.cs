using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySqlParser.TerminalApp
{
    public class TestErrorListener : BaseErrorListener, IAntlrErrorListener<int>
    {
        private readonly StringBuilder lastErrors;

        public TestErrorListener(StringBuilder lastErrors = null)
        {
            this.lastErrors = lastErrors ?? new StringBuilder();
        }

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            base.SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e);
            HandleSyntaxError(line, charPositionInLine, msg);
        }
        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            HandleSyntaxError(line, charPositionInLine, msg);
        }

        private void HandleSyntaxError(int line, int charPositionInLine, string msg)
        {
            if (lastErrors.Length != 0)
            { lastErrors.Append(Environment.NewLine); }
            lastErrors.Append($"line {line}:{charPositionInLine} {msg}");
        }

    }
}
