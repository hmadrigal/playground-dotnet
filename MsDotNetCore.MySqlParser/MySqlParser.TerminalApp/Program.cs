using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MySqlParser.TerminalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.TraceInformation(@"Press <ESC> to quit...");
            Task.Run(() =>
            {
                var mySqlParserTester = new MySqlParserTester();
                mySqlParserTester.parse();
            });
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
