using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleConsoleApplication.Services
{
    [Serializable]
    public class BlockServiceException : Exception
    {
        public BlockServiceException() { }
        public BlockServiceException(string message) : base(message) { }
        public BlockServiceException(string message, Exception inner) : base(message, inner) { }
        protected BlockServiceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
