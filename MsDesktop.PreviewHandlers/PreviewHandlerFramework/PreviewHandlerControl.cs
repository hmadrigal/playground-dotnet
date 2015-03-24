// Stephen Toub
// Coded and published in January 2007 issue of MSDN Magazine 
// http://msdn.microsoft.com/msdnmag/issues/07/01/PreviewHandlers/default.aspx

using System;
using System.IO;
using System.Windows.Forms;

namespace C4F.DevKit.PreviewHandler.PreviewHandlerFramework
{
    public abstract class PreviewHandlerControl : Form
    {
        protected PreviewHandlerControl()
        {
            base.FormBorderStyle = FormBorderStyle.None;
        }

        public new abstract void Load(FileInfo file);
        public new abstract void Load(Stream stream);

        public virtual void Unload()
        {
            foreach (Control c in Controls) c.Dispose();
            Controls.Clear();
        }

        protected static string CreateTempPath(string extension)
        {
            return Path.GetTempPath() + Guid.NewGuid().ToString("N") + extension;
        }
    }
}
