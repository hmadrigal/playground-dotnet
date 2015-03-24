// Stephen Toub
// Coded and published in January 2007 issue of MSDN Magazine 
// http://msdn.microsoft.com/msdnmag/issues/07/01/PreviewHandlers/default.aspx

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace C4F.DevKit.PreviewHandler.PreviewHandlerFramework
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct COLORREF
    {
        public uint Dword;
        public Color Color
        {
            get
            {
                return Color.FromArgb(
                    (int)(0x000000FFU & Dword),
                    (int)(0x0000FF00U & Dword) >> 8,
                    (int)(0x00FF0000U & Dword) >> 16);
            }
        }
    }
}
