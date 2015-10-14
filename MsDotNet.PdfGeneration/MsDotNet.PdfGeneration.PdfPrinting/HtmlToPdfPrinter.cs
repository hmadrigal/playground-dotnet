using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkHtmlToXSharp;

namespace PdfGeneration.PdfPrinting
{
    // See more information about the WkHtmlTox
    // https://github.com/vilppu/OpenHtmlToPdf
    // http://wkhtmltopdf.org/libwkhtmltox/pagesettings.html
    // https://madalgo.au.dk/~jakobt/wkhtmltoxdoc/wkhtmltopdf-0.9.9-doc.html

    public class HtmlToPdfPrinter
    {
        static HtmlToPdfPrinter()
        {

            WkHtmlToXLibrariesManager.Register(new Win32NativeBundle());
            WkHtmlToXLibrariesManager.Register(new Win64NativeBundle());
        }

        public void Print(string htmlFilePath, string pdfFilePath)
        {
            using (System.IO.Stream pdfStreamWriter = System.IO.File.OpenWrite(pdfFilePath))
            using (var multiplexingConverter = GetDefaultConverter(
                setUpAction: m => m.ObjectSettings.Page = new Uri(htmlFilePath).ToString()
            ))
            {
                var pdfBytes = multiplexingConverter.Convert();
                pdfStreamWriter.Write(pdfBytes, 0, pdfBytes.Length);
                pdfStreamWriter.Flush();
            }
        }

        public void Print(System.IO.Stream htmlStream, System.IO.Stream pdfStream)
        {
            using (System.IO.TextReader htmlReader = new System.IO.StreamReader(htmlStream))
            {
                Print(htmlReader, pdfStream);
            }
        }

        public void Print(System.IO.TextReader htmlReader, System.IO.Stream pdfStream)
        {
            var htmlContent = htmlReader.ReadToEnd();
            Print(htmlContent, pdfStream);
        }

        public void Print(string htmlContent, System.IO.Stream pdfStream)
        {
            using (var multiplexingConverter = GetDefaultConverter())
            {
                var pdfBytes = multiplexingConverter.Convert(htmlContent);
                pdfStream.Write(pdfBytes, 0, pdfBytes.Length);
                pdfStream.Flush();
            }
        }

        private IHtmlToPdfConverter GetDefaultConverter(Action<IHtmlToPdfConverter> setUpAction = null)
        {
            var multiplexingConverter = new MultiplexingConverter();
            multiplexingConverter.ObjectSettings.Web.PrintMediaType = true;
            multiplexingConverter.GlobalSettings.Margin.Top = "1.25cm";
            multiplexingConverter.GlobalSettings.Margin.Bottom = "1.25cm";
            multiplexingConverter.GlobalSettings.Margin.Left = "1.25cm";
            multiplexingConverter.GlobalSettings.Margin.Right = "1.25cm";

            multiplexingConverter.ObjectSettings.Load.BlockLocalFileAccess = false;
            multiplexingConverter.ObjectSettings.Web.LoadImages = true;
            multiplexingConverter.ObjectSettings.Web.PrintMediaType = true;

            if (setUpAction != null)
                setUpAction(multiplexingConverter);
            return multiplexingConverter;
        }
    }
}
