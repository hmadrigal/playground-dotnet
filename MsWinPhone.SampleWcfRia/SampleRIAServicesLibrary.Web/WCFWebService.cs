using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;

namespace SampleRIAServicesLibrary.Web
{
    [EnableClientAccess]
    public class WCFWebService : DomainService
    {
        [Invoke]
        public String GetMessage(String input)
        {
            var message = new System.Text.StringBuilder();
            message.AppendFormat("[Server Start Time] {0}", DateTime.Now);
            //This represents a ver slow operation
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));
            message.AppendFormat("[Server End Time  ] {0}", DateTime.Now);
            message.AppendFormat("[Message = {0}]", input);
            return message.ToString();
        }
    }
}
