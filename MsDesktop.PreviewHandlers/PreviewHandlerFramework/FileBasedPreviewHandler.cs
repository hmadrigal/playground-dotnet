// Stephen Toub
// Coded and published in January 2007 issue of MSDN Magazine 
// http://msdn.microsoft.com/msdnmag/issues/07/01/PreviewHandlers/default.aspx

using System;
using System.IO;

namespace C4F.DevKit.PreviewHandler.PreviewHandlerFramework
{
    public abstract class FileBasedPreviewHandler : PreviewHandler, IInitializeWithFile
    {
        private string _filePath;

        void IInitializeWithFile.Initialize(string pszFilePath, uint grfMode)
        {
            _filePath = pszFilePath;
        }

        protected override void Load(PreviewHandlerControl c)
        {
            c.Load(new FileInfo(_filePath));
        }
    }
}
