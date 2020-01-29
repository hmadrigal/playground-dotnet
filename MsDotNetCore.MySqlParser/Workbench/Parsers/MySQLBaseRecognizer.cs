using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.IO;
using System.Text;

namespace Workbench.Parsers
{
    public abstract class MySQLBaseRecognizer : Antlr4.Runtime.Parser, IMySQLRecognizerCommon
    {
        #region IMySQLRecognizerCommon

        protected IMySQLRecognizerCommon mySQLRecognizerCommon = new MySQLRecognizerCommon();

        public int serverVersion { get => mySQLRecognizerCommon.serverVersion; set => mySQLRecognizerCommon.serverVersion = value; }
        public SqlMode sqlMode { get => mySQLRecognizerCommon.sqlMode; set => mySQLRecognizerCommon.sqlMode = value; }

        public IParseTree contextFromPosition(IParseTree root, int position) => mySQLRecognizerCommon.contextFromPosition(root, position);

        public string dumpTree(RuleContext context, IVocabulary vocabulary) => mySQLRecognizerCommon.dumpTree(context, vocabulary);

        public IParseTree getNext(IParseTree tree) => mySQLRecognizerCommon.getNext(tree);

        public IParseTree getNextSibling(IParseTree tree) => mySQLRecognizerCommon.getNextSibling(tree);

        public IParseTree getPrevious(IParseTree tree) => mySQLRecognizerCommon.getPrevious(tree);

        public IParseTree getPreviousSibling(IParseTree tree) => mySQLRecognizerCommon.getPreviousSibling(tree);

        public bool isSqlModeActive(SqlMode mode) => isSqlModeActive((int)mode);

        public bool isSqlModeActive(int mode) => mySQLRecognizerCommon.isSqlModeActive(mode);

        public string sourceTextForContext(ParserRuleContext ctx, bool keepQuotes) => mySQLRecognizerCommon.sourceTextForContext(ctx, keepQuotes);

        public string sourceTextForRange(IParseTree start, IParseTree stop, bool keepQuotes) => mySQLRecognizerCommon.sourceTextForRange(start, stop, keepQuotes);

        public string sourceTextForRange(IToken start, IToken stop, bool keepQuotes) => mySQLRecognizerCommon.sourceTextForRange(start, stop, keepQuotes);

        public void sqlModeFromString(string modes) => mySQLRecognizerCommon.sqlModeFromString(modes);
        #endregion

        public MySQLBaseRecognizer(Antlr4.Runtime.ITokenStream input, IMySQLRecognizerCommon mySQLRecognizerCommon = null) : base(input)
        { this.mySQLRecognizerCommon = mySQLRecognizerCommon ?? new MySQLRecognizerCommon(); }

        public MySQLBaseRecognizer(ITokenStream input, TextWriter output, TextWriter errorOutput, IMySQLRecognizerCommon mySQLRecognizerCommon = null) : base(input, output, errorOutput)
        { this.mySQLRecognizerCommon = mySQLRecognizerCommon ?? new MySQLRecognizerCommon(); }

        public static string getText(Antlr4.Runtime.RuleContext context, bool convertEscapes)
        {
            var result = new StringBuilder();
            if (context is Parsers.MySQLParser.TextLiteralContext textLiteralContext && textLiteralContext != null)
            {
                var list = textLiteralContext.textStringLiteral();
                var lastType = Antlr4.Runtime.TokenConstants.InvalidType;
                var lastIndex = ParsersCommon.InvalidIndex;
                foreach (var entry in list)
                {
                    var token = entry.value;
                    switch (token.Type)
                    {
                        case MySQLParser.DOUBLE_QUOTED_TEXT:
                        case MySQLParser.SINGLE_QUOTED_TEXT:
                            var text = token.Text;
                            var quoteChar = text[0];
                            var doubledQuoteChar = new string(quoteChar, 2);
                            if (lastType == token.Type && lastIndex + 1 == token.TokenIndex)
                            {
                                result.Append(quoteChar);
                            }
                            lastType = token.Type;
                            lastIndex = token.TokenIndex;

                            text = text.Substring(1, text.Length - 2);
                            int position = text.IndexOf(doubledQuoteChar);
                            if (position >= 0)
                            { text = text.Replace(doubledQuoteChar, quoteChar.ToString()); }
                            result.Append(text);
                            break;
                    }
                }
                if (convertEscapes)
                {
                    var temp = result.ToString();
                    result.Clear();
                    var pendingEscape = false;
                    for (int ci = 0; ci < temp.Length; ci++)
                    {
                        var c = temp[ci];
                        if (pendingEscape)
                        {
                            pendingEscape = false;
                            switch (c)
                            {
                                case 'n':
                                    c = '\n';
                                    break;
                                case 't':
                                    c = '\t';
                                    break;
                                case 'r':
                                    c = '\r';
                                    break;
                                case 'b':
                                    c = '\b';
                                    break;
                                case '0':
                                    c = '\u0000';
                                    break; // ASCII null
                                case 'Z':
                                    c = '\u0032';
                                    break; // Win32 end of file
                            }
                        }
                        else if (c == '\\')
                        {
                            pendingEscape = true;
                            continue;
                        }
                        result.Append(c);
                    }

                    if (pendingEscape)
                    { result.Append("\\"); }
                }
                return result.ToString();
            }

            return context.GetText();
        }

        public bool look(int position, int expected)
        {
            return this.InputStream.LA(position) == expected;
        }

        public bool containsLinebreak(string text)
        {
            return text.Contains("\r\n");
        }
    }
}
