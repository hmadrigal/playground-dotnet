using PdfGeneration.Data;
using PdfGeneration.PdfPrinting;
using PdfGeneration.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataProvider = new DataProvider();
            var templateRender = new TemplateRender();
            var htmlToPdfPrinter = new HtmlToPdfPrinter();
            templateRender.AddKnownType();
            var workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var pdfFilePath = System.IO.Path.Combine(workingDirectory, @"Report.pdf");
            var templateFilePath = System.IO.Path.Combine(workingDirectory, @"Assets/Report.html");
            var templateDirectoryPath = System.IO.Path.GetDirectoryName(templateFilePath);

            if (System.IO.File.Exists(pdfFilePath))
                System.IO.File.Delete(pdfFilePath);

            dynamic reportData = dataProvider.GetReportData();

            #region Printing Using Stream
            //using (System.IO.Stream htmlStream = new System.IO.MemoryStream())
            //{
            //    templateRender.RenderTemplate(templateFilePath, htmlStream, reportData, hasToLeaveStreamOpen: true);
            //    htmlStream.Seek(0, System.IO.SeekOrigin.Begin);
            //    using (var pdfStreamWriter = System.IO.File.OpenWrite(pdfFilePath))
            //    {
            //        htmlToPdfPrinter.Print(htmlStream, pdfStreamWriter);
            //    }
            //}
            #endregion

            #region Printing Using StringBuilder
            var htmlStringBuilder = new StringBuilder();
            using (System.IO.TextWriter htmlTextWriter = new System.IO.StringWriter(htmlStringBuilder))
            {
                templateRender.RenderTemplate(templateFilePath, htmlTextWriter, reportData);
            }
            using (var pdfStreamWriter = System.IO.File.OpenWrite(pdfFilePath))
            {
                var htmlContent = htmlStringBuilder.ToString();
                htmlToPdfPrinter.Print(htmlContent, pdfStreamWriter);
            }
            #endregion

            System.Diagnostics.Process.Start(pdfFilePath);
        }
    }
}
