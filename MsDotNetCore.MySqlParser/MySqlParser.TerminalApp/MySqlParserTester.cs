using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Workbench.Parsers;

namespace MySqlParser.TerminalApp
{
    class MySqlParserTester
    {
        private HashSet<string> charsets;
        private readonly StringBuilder lastErrors;
        private SqlMode sqlMode;
        private int serverVersion;
        private bool buildParserTree;
        private bool dump;
        private string parseTreeView;

        public MySqlParserTester()
        {
            charsets = new HashSet<string>(new string[]{
                "_utf8", "_utf8mb3", "_utf8mb4", "_ucs2",
                "_big5",   "_latin2", "_ujis", "_binary",
                "_cp1250", "_latin1"
            });
            lastErrors = new StringBuilder();
            sqlMode = SqlMode.AnsiQuotes | SqlMode.IgnoreSpace;
            serverVersion = MySqlServerVersion.MAX_SERVER_VERSION;
            //serverVersion = MySqlVersionNumbers.MYSQL_VERSION_5_7_6;
            dump = true;
            buildParserTree = true;
            parseTreeView = string.Empty;
        }

        private int parseQuery(string query)
        {
            var t = string.Empty;
            IMySQLRecognizerCommon mySQLRecognizerCommon = new MySQLRecognizerCommon(serverVersion, sqlMode);
            var lastErrors = new StringBuilder();
            var errorListener = new TestErrorListener(lastErrors);
            var errorStrategy = new BailErrorStrategy();
            var input = new AntlrInputStream(query);
            var lexer = new MySQLLexer(input, mySQLRecognizerCommon);
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errorListener);

            lexer.serverVersion = serverVersion;
            lexer.sqlMode = sqlMode;
            lexer.charsets = charsets;
            var tokens = new CommonTokenStream(lexer);

            var parser = new MySQLParser(tokens, mySQLRecognizerCommon);
            parser.serverVersion = serverVersion;
            parser.sqlMode = sqlMode;
            parser.BuildParseTree = buildParserTree;

            parser.ErrorHandler = errorStrategy;
            parser.Interpreter.PredictionMode = PredictionMode.SLL;
            parser.RemoveParseListeners();

            tokens.Fill();

            ParserRuleContext tree = default;
            try
            {
                tree = parser.query();
            }
            catch (Antlr4.Runtime.Misc.ParseCanceledException)
            {
                // If parsing was cancelled we either really have a syntax error or we need to do a second step,
                // now with the default strategy and LL parsing.
                tokens.Reset();
                parser.Reset();
                parser.ErrorHandler = new DefaultErrorStrategy();
                parser.Interpreter.PredictionMode = PredictionMode.LL;
                parser.AddErrorListener(errorListener);

                tree = parser.query();
            }

            var toks = tokens.GetTokens();
            t = input.GetText(new Antlr4.Runtime.Misc.Interval(toks[0].StartIndex, int.MaxValue));

            if (dump && buildParserTree)
            {
                if (tree == null)
                {
                    Trace.TraceInformation(@"No parse tree available");
                }
                else
                {
                    t = tree.GetText();
                    parseTreeView = tree.ToStringTree(parser);
                    var text = $"Token count: {tokens.Size}{Environment.NewLine}{MySQLRecognizerCommon.dumpTree(tree, parser.Vocabulary)}";
                    Trace.TraceInformation(text.Trim());
                }
            }

            return parser.NumberOfSyntaxErrors;
        }

        public void parse()
        {

            var resources = new System.Resources.ResourceManager("MySqlParser.TerminalApp.Queries", typeof(MySqlParserTester).Assembly);
            for (int i = 1; i <= 13; i++)
            {
                Trace.TraceInformation($"BEGIN ==========================[sql{i}]");
                var singleQueryText = resources.GetString($"sql{i}");
                Trace.TraceInformation($"SQL:\n{singleQueryText.Trim()}");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var errorCount = parseQuery(singleQueryText);
                stopwatch.Stop();
                Trace.TraceInformation($"Parse time: {stopwatch.Elapsed}");
                if (errorCount > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Trace.TraceError($"{errorCount} errors found\n{lastErrors.ToString()}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Trace.TraceInformation("No errors found");
                    Console.ResetColor();
                }
                Trace.TraceInformation($"END ============================[sql{i}]");
            }

        }
    }


}
