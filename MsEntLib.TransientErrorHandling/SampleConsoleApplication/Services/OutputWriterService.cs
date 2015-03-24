using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SampleConsoleApplication.Services
{
    public class OutputWriterService
    {
        public void WriteLine(string format, params object[] args)
        {
            Debug.WriteLine(format, args);
            Console.WriteLine(format, args);
        }
    }
}
