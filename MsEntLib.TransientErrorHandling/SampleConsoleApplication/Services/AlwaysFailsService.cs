using System.IO;

namespace SampleConsoleApplication.Services
{
    class AlwaysFailsService : BaseService, IService
    {
        public AlwaysFailsService(OutputWriterService writer) : base(writer) { }

        public void DoSlowAndImportantTask()
        {
            Writer.WriteLine("Start AlwaysFailsService");
            Sleep();
            throw new FileNotFoundException();
        }

        public void DoAnImportantTask()
        {
            throw new FileNotFoundException();
        }
    }
}
