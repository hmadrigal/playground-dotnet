using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Workbench.Parsers
{
    public interface IMySQLRecognizerCommon
    {
        int serverVersion { get; set; }
        SqlMode sqlMode { get; set; }

        IParseTree contextFromPosition(IParseTree root, int position);
        string dumpTree(RuleContext context, IVocabulary vocabulary);
        IParseTree getNext(IParseTree tree);
        IParseTree getNextSibling(IParseTree tree);
        IParseTree getPrevious(IParseTree tree);
        IParseTree getPreviousSibling(IParseTree tree);
        bool isSqlModeActive(Workbench.Parsers.SqlMode mode);
        bool isSqlModeActive(int mode);
        string sourceTextForContext(ParserRuleContext ctx, bool keepQuotes);
        string sourceTextForRange(IParseTree start, IParseTree stop, bool keepQuotes);
        string sourceTextForRange(IToken start, IToken stop, bool keepQuotes);
        void sqlModeFromString(string modes);
    }
}