// Stephen Toub
// Coded and published in January 2007 issue of MSDN Magazine 
// http://msdn.microsoft.com/msdnmag/issues/07/01/PreviewHandlers/default.aspx

using System;
using System.Runtime.InteropServices;

namespace C4F.DevKit.PreviewHandler.PreviewHandlerFramework
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        private IntPtr hwnd;
        public int message;
        private IntPtr wParam;
        private IntPtr lParam;
        public int time;
        public int pt_x;
        public int pt_y;
    }
}
