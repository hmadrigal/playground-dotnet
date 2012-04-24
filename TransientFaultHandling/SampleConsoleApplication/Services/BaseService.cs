using System.Threading;
using System;

namespace SampleConsoleApplication.Services
{
    public class BaseService
    {
        protected OutputWriterService Writer { get; private set; }
        public BaseService(OutputWriterService writer)
        {
            Writer = writer;
        }

        protected void Sleep(TimeSpan? timeToSleep =null )
        {
            Thread.Sleep(timeToSleep.HasValue ? timeToSleep.Value : TimeSpan.Zero);
        }
    }
}
