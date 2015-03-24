// Stephen Toub
// Coded and published in January 2007 issue of MSDN Magazine 
// http://msdn.microsoft.com/msdnmag/issues/07/01/PreviewHandlers/default.aspx

using System;
using System.IO;

namespace C4F.DevKit.PreviewHandler.PreviewHandlerFramework
{
    public abstract class StreamBasedPreviewHandlerControl : PreviewHandlerControl
    {
        public sealed override void Load(FileInfo file)
        {
            using (FileStream fs = new FileStream(file.FullName,
                FileMode.Open, FileAccess.Read, FileShare.Delete | FileShare.ReadWrite))
            {
                Load(fs);
            }
        }
    }
}
