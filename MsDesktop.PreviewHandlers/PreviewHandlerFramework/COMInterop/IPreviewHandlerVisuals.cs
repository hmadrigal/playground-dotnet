// Stephen Toub
// Coded and published in January 2007 issue of MSDN Magazine 
// http://msdn.microsoft.com/msdnmag/issues/07/01/PreviewHandlers/default.aspx

using System;
using System.Runtime.InteropServices;

namespace C4F.DevKit.PreviewHandler.PreviewHandlerFramework
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8327b13c-b63f-4b24-9b8a-d010dcc3f599")]
    interface IPreviewHandlerVisuals
    {
        void SetBackgroundColor(COLORREF color);
        void SetFont(ref LOGFONT plf);
        void SetTextColor(COLORREF color);
    }
}
