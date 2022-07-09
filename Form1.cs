using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPdf;
using iText.Html2pdf;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing.Imaging;
using System.Resources;
using SDSP.Properties;

namespace SDSP
{
    public partial class Form1 : Form
    {
        String html = @"<html>

<head>
  <meta http-equiv='content-type' content='text/html; charset=utf-8' />

  <title></title>
  <style type='text/css' media='all'>
    /*div {s
      border: 0.5px solid black;
    }*/

    @media print {
      body {
        width: 21cm;
        height: 29.7cm;
        margin: 30mm 45mm 30mm 45mm;
        /* change the margins as you want them to be. */
      }
    }

    body {
      /*border: 1px solid black;*/
      width: 21cm;
      height: 29.7cm;
      margin: 30mm 45mm 30mm 45mm;
      /*width: 60%;
      zoom: 0.95;*/
      margin: auto;
      font-family: 'Courier New', Courier, monospace;
    }

    table {

      width: 100%;
      table-layout: fixed;
      border: 2px solid black;
      border-collapse: collapse;
    }

    td {
      background-color: #D5F3FE;
    }

    th {
      background-color: #70C8FF;
      color: white;
    }

    .logo {
      float: left;
      width: 7rem;
      border-radius: 100%;
      position: absolute;
      margin-left: 1%;
    }

    .school-name {
      text-align: center;
    }

    .student-info-table {
      width: 100%;
      table-layout: fixed;
      border: 2px solid black;
      border-collapse: collapse;
    }

    .student-info-table td,
    .student-info-table th {
      border: 1px solid black;
      color: #000;
      text-align: left;
      padding: 5px 0px 5px 10px;
    }

    .main-marks-table {
      width: 100%;
      table-layout: fixed;
      border: 2px solid black;
      border-collapse: collapse;
    }

    .main-marks-table td,
    .main-marks-table th {
      padding: 5px;
      border-bottom: 1px solid black;
      text-align: center;
    }

    /*.main-marks-table td:first-child,
    .main-marks-table th:first-child {
      border-right: 1px solid black;;
    }*/

    .width-of-suject {
      width: 20%;
    }

    .table-csa {
      width: auto;
    }

    .table-csa td:first-child,
    .table-csa th:first-child {
      padding: 5px 50px 5px 10px;
    }

    .table-csa td,
    .table-csa th {
      padding: 5px 10px;
      border-bottom: 1px solid black;
    }

    .csa1-table {
      float: left;
      width: auto;
    }

    .csa2-table {
      width: auto;
      float: right;
    }

    .csa1-table td:last-child,
    .csa2-table td:last-child {
      text-align: center;
    }
  </style>

</head>

<body>

  <img src='' class='logo' alt='' />
  <h1 class='school-name'>SUSHILA DEVI PUBLIC SCHOOL</h1>
  <h3 class='school-name'>B-68, YADAV NAGAR, SAMEYPUR, DELHI-110042</h3>
  <h3 class='school-name'>Annual Performance Report</h3>

  <br />
  <br />
  <br />

  <div>
    <div style='float: left;'>Student Information</div>
    <div style='text-align:right'>SESSION:2021-22</div>
  </div>

  <br />
  <br />

  <div class='student-info-div'>
    <table class='student-info-table' cellpadding=3px cellspacing=3px>
      <tr>
        <th>NAME:</th>
        <td></td>
        <th>ADMISSION NUMBER:</th>
        <td></td>
      </tr>
      <tr>
        <th>FATHER'S NAME:</th>
        <td></td>
        <th>CLASS:</th>
        <td></td>
      </tr>
      <tr>
        <th>MOTHER'S NAME</th>
        <td></td>
        <th>SECTION:</th>
        <td></td>
      </tr>
      <tr>
        <th>D.O.B:</th>
        <td></td>
        <th>ATTENDANCE:</th>
        <td></td>
      </tr>
    </table>
  </div>

  <br />
  <br />

  <div class='main-marks-div'>
    <table class='main-marks-table'>
      <tr>
        <th>SUBJECT</th>
        <th>FA1<br><label style='font-size: smaller;'>(MM10)</label></th>
        <th>FA2</th>
        <th>SA1</th>
        <th>FA3</th>
        <th>FA4</th>
        <th>SA2</th>
        <th>GRAND TOTAL</th>
        <th>GRADE</th>
      </tr>
      <tr>
        <td class='sub-name'>ENGLISH</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
      </tr>
      <tr>
        <td class='sub-name'>HINDI</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
      </tr>
      <tr>
        <col span=1 class='width-of-suject' />
        <td class='sub-name'>MATHEMATICS</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
      </tr>
      <tr>
        <td class='sub-name'>SOCIAL STUDIES</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
      </tr>
      <tr>
        <td class='sub-name'>SCIENCE</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
      </tr>
      <tr>
        <td class='sub-name'>TOTAL</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
      </tr>
    </table>
  </div>
  <br />
  <div class='' style='width: 100%; text-align: right; font-weight: bold; font-size: larger;'>
    PERCENTAGE: %
  </div>
  <br />
  <br />
  <div class='table-csa-div' style='width: 100%;'>
    <div class='csa1-div' style='float: left;'>
      <table class='table-csa csa1-table'>
        <tr>
          <th>SUBJECT</th>
          <th>GRADE</th>
        </tr>
        <tr>
          <td>ART & CRAFT</td>
          <td></td>
        </tr>
        <tr>
          <td>COMPUTER</td>
          <td></td>
        </tr>
        <tr>
          <td>MORAL EDUCATION & GK</td>
          <td></td>
        </tr>
      </table>
    </div>
    <div class='csa2-div' style='float: right; width: auto;'>
      <table class='table-csa csa2-table'>
        <tr>
          <th>SUBJECT</th>
          <th>GRADE</th>
        </tr>
        <tr>
          <td>WORK EDUCATION</td>
          <td></td>
        </tr>
        <tr>
          <td>HEALTH AND PHYSICAL EDUCATION</td>
          <td></td>
        </tr>
        <tr>
          <td>PARTICIPATION ACTIVITIES</td>
          <td></td>
        </tr>
        <tr>
          <td>ATTITUDE TOWARDS CLASSMATE</td>
          <td></td>
        </tr>
      </table>
    </div>
  </div>
</body>

</html>
                            ";
        string html2;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HTMLAndMarking html1 = new HTMLAndMarking("FA1");
            html2 = html1.getHTMLCode();
            // MessageBox.Show(Directory.GetCurrentDirectory() + "\\Resources\\Logo.jepg");

            //MessageBox.Show(html2);
            gg();
            textBox1.Text = html2;
        }

        private void Generate()
        {
            string pdfDest =  "D:\\output.pdf";
            string ORIG = "C:\\Users\\acer\\Desktop\\New folder\\Annual.html";
            HtmlConverter.ConvertToPdf(new FileStream(ORIG, FileMode.Open, FileAccess.Read, FileShare.Read), new FileStream(pdfDest, FileMode.Create));

        }

        private void gg ()
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
            var doc = Renderer.RenderHtmlAsPdf(html2);
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

        private void crop_pdf()
        {
            int x = 594;
            int y = 830;
            int a = 0;
            int b = 100;

            var file = "D:\\google_chrome.pdf";
            var oldchar = "google_chrome.pdf";
            var repChar = "g.pdf";
            int pageNumber = 1;
            PdfReader reader = new PdfReader(file);
            iTextSharp.text.Rectangle size = new iTextSharp.text.Rectangle(
            x,
            y,
            a,
            b);
            Document document = new Document(size);
            PdfWriter writer = PdfWriter.GetInstance(document,
            new FileStream(file.Replace(oldchar, repChar),
            FileMode.Create, FileAccess.Write));
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            document.NewPage();
            PdfImportedPage page = writer.GetImportedPage(reader,
            pageNumber);
            cb.AddTemplate(page, 0, 0);
            document.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = html;
        }
    }
}
