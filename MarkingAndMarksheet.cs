using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;

namespace SDSP
{
    class MarkingAndMarksheet
    {
        string html;
        public MarkingAndMarksheet()
        {

        }
        public MarkingAndMarksheet(int session)
        {

        }
        public MarkingAndMarksheet(int session, int admNo)
        {

        }

        private void printFuntion()
        {
            ChromePdfRenderer Renderer = new ChromePdfRenderer();

            //// Add a header to every page easily
            //Renderer.RenderingOptions.FirstPageNumber = 1; // use 2 if a coverpage  will be appended
            //Renderer.RenderingOptions.TextHeader.DrawDividerLine = true;
            //Renderer.RenderingOptions.TextHeader.CenterText = "{url}";
            //Renderer.RenderingOptions.TextHeader.FontFamily = "Helvetica,Arial";
            //Renderer.RenderingOptions.TextHeader.FontSize = 12;

            //// Add a footer too
            //Renderer.RenderingOptions.TextFooter.DrawDividerLine = true;
            //Renderer.RenderingOptions.TextFooter.FontFamily = "Arial";
            //Renderer.RenderingOptions.TextFooter.FontSize = 10;
            //Renderer.RenderingOptions.TextFooter.LeftText = "{date} {time}";
            //Renderer.RenderingOptions.TextFooter.RightText = "{page} of {total-pages}";

            // Mergable fields are:
            // {page} {total-pages} {url} {date} {time} {html-title} & {pdf-title}

            IronPdf.Installation.DefaultRenderingEngine = IronPdf.Rendering.PdfRenderingEngine.Chrome;
            //var Renderer = new IronPdf.ChromePdfRenderer();
            //ChromePdfRenderer Renderer = new ChromePdfRenderer();
            Renderer.RenderingOptions.FitToPaper = true;
            Renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Screen;
            Renderer.RenderingOptions.PrintHtmlBackgrounds = true;
            Renderer.RenderingOptions.CreatePdfFormsFromHtml = true;
            var doc = Renderer.RenderHtmlAsPdf(html);
            //var doc = Renderer.RenderUrlAsPdf("https://www.google.com/");
            //var doc = Renderer.RenderHtmlFileAsPdf("example.html");
            doc.SaveAs("D:\\google_chrome.pdf");
            //var PDF = Renderer.RenderHtmlAsPdf("<h1>Hello IronPdf</h1>");
            //var OutputPath = "D:\\pixel-perfect.pdf";
            //PDF.SaveAs(OutputPath);

            //ChromePdfRenderer Renderer = new ChromePdfRenderer();
            //Renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print;
            //Renderer.RenderingOptions.PrintHtmlBackgrounds = false;
            //Renderer.RenderingOptions.CreatePdfFormsFromHtml = false;
            //var doc = Renderer.RenderUrlAsPdf("https://www.google.com/");
        }

        private void marking ()
        {

        }

        private void printAll ()
        {

        }

        private void print ()
        {

        }

        private void get()
        {

        }
    }
}
