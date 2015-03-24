// Stephen Toub
// Coded and published in January 2007 issue of MSDN Magazine 
// http://msdn.microsoft.com/msdnmag/issues/07/01/PreviewHandlers/default.aspx

using System;
using System.Runtime.InteropServices;

namespace C4F.DevKit.PreviewHandler.PreviewHandlerFramework
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("fec87aaf-35f9-447a-adb7-20234491401a")]
    interface IPreviewHandlerFrame
    {
        void GetWindowContext(IntPtr pinfo);
        [PreserveSig]
        uint TranslateAccelerator(ref MSG pmsg);
    };
}
