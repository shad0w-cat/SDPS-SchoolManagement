using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using iTextSharp;
using iTextSharp.tool.xml;
using System.Drawing.Printing;
using AxSHDocVw;
//using mshtml;
using CefSharp.WinForms;
using CefSharp;
using iText.Html2pdf;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using PdfSharp.Drawing;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Forms;
using TheArtOfDev.HtmlRenderer;
using TheArtOfDev.HtmlRenderer.WinForms;
using TheArtOfDev.HtmlRenderer.Adapters.Entities;
using TheArtOfDev.HtmlRenderer.Core;
using TheArtOfDev.HtmlRenderer.Core.Entities;
using TheArtOfDev.HtmlRenderer.Core.Utils;
using TheArtOfDev.HtmlRenderer.PdfSharp.Adapters;
using TheArtOfDev.HtmlRenderer.PdfSharp.Utilities;
using IronPdf;
using IronPdf.Exceptions;


namespace SDSP
{
    public partial class ETC : Form
    {
        ChromiumWebBrowser browser;

        String html = @"<html>

                        <head>
                          <meta http-equiv='content-type' content='text/html; charset=utf-8' />

                          <title></title>
                          <style type='text/css' media='all'>
                            /*div {
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

                            img {
                              float: left;
                              width: 12%;
                              border-radius: 100%;
                              position: absolute;
                              margin-left: 5%;
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

                          <img src='C:\Users\acer\Desktop\New folder\Logo.jpeg' class='logo' alt='' style='float: left; width: 10vw; border-radius: 100%; position: absolute; margin-left: 5%;' />
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
                                <td style='background-color: #D5F3FE;'>Hello Its mes</td>
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
                                <th>FA1<br /><label style='font-size: 10px;'>(MM10)</label></th>
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

        public ETC()
        {
            InitializeComponent();
            CefSettings sett = new CefSettings();

            Cef.Initialize(sett);
            browser = new ChromiumWebBrowser();
            browser.Dock = DockStyle.Right;
            browser.Width = 500;
            

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            /*Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("D:\\Pdf.pdf", FileMode.Create));
            doc.Open();
            Paragraph p1 = new Paragraph(@"<body>
                            < h1 > Sushila Devi Public School </ h1 >
                        < p > hello there </ p >
                            ");
            HTMLWorker wrkr = new HTMLWorker(doc);
            wrkr.Parse(p1);
            doc.Add(wrkr);
            doc.Close();
            MessageBox.Show("Pdf Creted");*/

            //createPDF(html);
            method3();
            webBrowser1.DocumentText = html;
            //webBrowser1.Print();
            //webBrowser1.ShowPageSetupDialog();
            //webBrowser1.ShowPrintDialog();
            //webBrowser1.ShowPrintPreviewDialog();
            //parse();
            //webBrowser1.Navigate("C:\\Users\\acer\\Desktop\\Deadlock.pdf");

        }

        private MemoryStream createPDF(string html)
        {
            MemoryStream msOutput = new MemoryStream();
            TextReader reader = new StringReader(html);

            // step 1: creation of a document-object
            Document document = new Document(iTextSharp.text.PageSize.A4, 30, 30, 30, 30);

            // step 2:
            // we create a writer that listens to the document
            // and directs a XML-stream to a file
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("D:\\Pdf.pdf", FileMode.Create));

            // step 3: we create a worker parse the document
            HTMLWorker worker = new HTMLWorker(document);

            // step 4: we open document and start the worker on the document
            document.Open();
            worker.StartDocument();

            // step 5: parse the html into the document
            worker.Parse(reader);

            // step 6: close the document and the worker
            worker.EndDocument();
            worker.Close();
            document.Close();

            return msOutput;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void method3()
        {
            Byte[] bytes;

            using (var ms = new MemoryStream())
            {
                using (var doc = new Document(iTextSharp.text.PageSize.A4))
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        doc.Open();

                        //Our sample HTML and CSS
                        //var example_html = @"<html>

                        //                    <head>
                        //                      <meta http-equiv='content-type' content='text/html; charset=utf-8' />

                        //                      <title></title>
                        //                      <style type='text/css' media='all'>
                        //                        /*div {
                        //                          border: 0.5px solid black;
                        //                        }*/

                        //                        body {
                        //                          width: 90%;
                        //                          margin: auto;
                        //                          font-family: 'Courier New', Courier, monospace;
                        //                        }

                        //                        table {
                        //                          width: 100%;
                        //                          table-layout: fixed;
                        //                          border: 2px solid black;
                        //                          border-collapse: collapse;
                        //                        }

                        //                        td {
                        //                          background-color: #D5F3FE;
                        //                        }

                        //                        th {
                        //                          background-color: #70C8FF;
                        //                          color: white;
                        //                        }

                        //                        img {
                        //                          float: left;
                        //                          width: 5%;
                        //                          border-radius: 100%;
                        //                          position: absolute;
                        //                          margin-left: 5%;
                        //                        }

                        //                        .school-name {
                        //                          text-align: center;
                        //                        }

                        //                        .student-info-table {
                        //                          width: 100%;
                        //                          table-layout: fixed;
                        //                          border: 2px solid black;
                        //                          border-collapse: collapse;
                        //                        }

                        //                        .student-info-table td,
                        //                        .student-info-table th {
                        //                          border: 1px solid black;
                        //                          color: #000;
                        //                          text-align: left;
                        //                          padding: 5px 0px 5px 10px;
                        //                        }

                        //                        .main-marks-table {
                        //                          width: 100%;
                        //                          table-layout: fixed;
                        //                          border: 2px solid black;
                        //                          border-collapse: collapse;
                        //                        }

                        //                        .main-marks-table td,
                        //                        .main-marks-table th {
                        //                          padding: 5px;
                        //                          border-bottom: 1px solid black;
                        //                          text-align: center;
                        //                        }

                        //                        /*.main-marks-table td:first-child,
                        //                        .main-marks-table th:first-child {
                        //                          border-right: 1px solid black;;
                        //                        }*/

                        //                        .width-of-suject {
                        //                          width: 20%;
                        //                        }

                        //                        .table-csa

                        //                        .table-csa td:first-child,
                        //                        .table-csa th:first-child {
                        //                          padding: 5px 50px 5px 10px;
                        //                        }

                        //                        .table-csa td,
                        //                        .table-csa th {
                        //                          padding: 5px 10px;
                        //                          border-bottom: 1px solid black;
                        //                        }

                        //                        .csa1-table {
                        //                          width: auto;
                        //                        }

                        //                        .csa2-table {
                        //                          width: auto;
                        //                          float: right;
                        //                        }

                        //                        .csa1-table td:last-child,
                        //                        .csa2-table td:last-child {
                        //                          text-align: center;
                        //                        }
                        //                      </style>

                        //                    </head>

                        //                    <body>

                        //                      <img src='Logo.jpeg' class='logo' alt='' />
                        //                      <h1 class='school-name'>SUSHILA DEVI PUBLIC SCHOOL</h1>
                        //                      <h3 class='school-name'>B-68, YADAV NAGAR, SAMEYPUR, DELHI-110042</h3>
                        //                      <h3 class='school-name'>Annual Performance Report</h3>

                        //                      <br />
                        //                      <br />
                        //                      <br />

                        //                      <div>
                        //                        <div style='float: left;'>Student Information</div>
                        //                        <div style='text-align:right'>SESSION:2021-22</div>
                        //                      </div>

                        //                      <br />
                        //                      <br />

                        //                      <div class='student-info-div'>
                        //                        <table class='student-info-table' cellpadding=3px >
                        //                          <tr>
                        //                            <th>NAME:</th>
                        //                            <td></td>
                        //                            <th>ADMISSION NUMBER:</th>
                        //                            <td></td>
                        //                          </tr>
                        //                          <tr>
                        //                            <th>FATHER'S NAME:</th>
                        //                            <td></td>
                        //                            <th>CLASS:</th>
                        //                            <td></td>
                        //                          </tr>
                        //                          <tr>
                        //                            <th>MOTHER'S NAME</th>
                        //                            <td></td>
                        //                            <th>SECTION:</th>
                        //                            <td></td>
                        //                          </tr>
                        //                          <tr>
                        //                            <th>D.O.B:</th>
                        //                            <td></td>
                        //                            <th>ATTENDANCE:</th>
                        //                            <td></td>
                        //                          </tr>
                        //                        </table>
                        //                      </div>

                        //                      <br />
                        //                      <br />

                        //                      <div class='main-marks-div'>
                        //                        <table class='main-marks-table'>
                        //                          <tr>
                        //                            <th>SUBJECT</th>
                        //                            <th>FA1</th>
                        //                            <th>FA2</th>
                        //                            <th>SA1</th>
                        //                            <th>FA3</th>
                        //                            <th>FA4</th>
                        //                            <th>SA2</th>
                        //                            <th>GRAND TOTAL</th>
                        //                            <th>GRADE</th>
                        //                          </tr>
                        //                          <tr>
                        //                            <td class='sub-name'>ENGLISH</td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                          </tr>
                        //                          <tr>
                        //                            <td class='sub-name'>HINDI</td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                          </tr>
                        //                          <tr>
                        //                            <col span=1 class='width-of-suject' />
                        //                            <td class='sub-name'>MATHEMATICS</td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                          </tr>
                        //                          <tr>
                        //                            <td class='sub-name'>SOCIAL STUDIES</td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                          </tr>
                        //                          <tr>
                        //                            <td class='sub-name'>SCIENCE</td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                          </tr>
                        //                          <tr>
                        //                            <td class='sub-name'>TOTAL</td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                            <td></td>
                        //                          </tr>
                        //                        </table>
                        //                      </div>
                        //                      <br />
                        //                      <div class='' style='width: 100%; text-align: right; font-weight: bold; font-size: larger;'>
                        //                        PERCENTAGE: %
                        //                      </div>
                        //                      <br />
                        //                      <br />
                        //                      <div class='table-csa-div' style='width: 100%;'>
                        //                        <div class='csa1-div' style='float: left;'>
                        //                          <table class='table-csa csa1-table'>
                        //                            <tr>
                        //                              <th>SUBJECT</th>
                        //                              <th>GRADE</th>
                        //                            </tr>
                        //                            <tr>
                        //                              <td>ART & CRAFT</td>
                        //                              <td></td>
                        //                            </tr>
                        //                            <tr>
                        //                              <td>COMPUTER</td>
                        //                              <td></td>
                        //                            </tr>
                        //                            <tr>
                        //                              <td>MORAL EDUCATION & GK</td>
                        //                              <td></td>
                        //                            </tr>
                        //                          </table>
                        //                        </div>
                        //                        <div class='csa2-div' style='float: right; width: auto;'>
                        //                          <table class='table-csa csa2-table'>
                        //                            <tr>
                        //                              <th>SUBJECT</th>
                        //                              <th>GRADE</th>
                        //                            </tr>
                        //                            <tr>
                        //                              <td>WORK EDUCATION</td>
                        //                              <td></td>
                        //                            </tr>
                        //                            <tr>
                        //                              <td>HEALTH AND PHYSICAL EDUCATION</td>
                        //                              <td></td>
                        //                            </tr>
                        //                            <tr>
                        //                              <td>PARTICIPATION ACTIVITIES</td>
                        //                              <td></td>
                        //                            </tr>
                        //                            <tr>
                        //                              <td>ATTITUDE TOWARDS CLASSMATE</td>
                        //                              <td></td>
                        //                            </tr>
                        //                          </table>
                        //                        </div>
                        //                      </div>
                        //                    </body>

                        //                    </html>
                        //    ";
                        var example_css = @" /*div {
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

    img {
      float: left;
      width: 12%;
      border-radius: 100%;
      /*position: absolute;*/
      margin-left: 5%;
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
    }";


                        /**************************************************
                         * Example #1                                     *
                         *                                                *
                         * Use the built-in HTMLWorker to parse the HTML. *
                         * Only inline CSS is supported.                  *
                         * ************************************************/

                        //Create a new HTMLWorker bound to our document
                        /*using (var htmlWorker = new HTMLWorker(doc))
                        {

                            //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
                            using (var sr = new StringReader(html))
                            {

                                //Parse the HTML
                                htmlWorker.Parse(sr);
                            }
                        }*/
                        

                        /**************************************************
                         * Example #2                                     *
                         *                                                *
                         * Use the XMLWorker to parse the HTML.           *
                         * Only inline CSS and absolutely linked          *
                         * CSS is supported                               *
                         * ************************************************/

                        //XMLWorker also reads from a TextReader and not directly from a string
                        using (var srHtml = new StringReader(html))
                        {

                            //Parse the HTML
                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                        }
                        

                        /**************************************************
                        * Example #3                                     *
                        *                                                *
                        * Use the XMLWorker to parse HTML and CSS        *
                        * ************************************************/

                        //In order to read CSS as a string we need to switch to a different constructor
                        //that takes Streams instead of TextReaders.
                        //Below we convert the strings into UTF8 byte array and wrap those in MemoryStreams
                      /* using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        {
                            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                            {

                                //Parse the HTML
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                   
                            }
                        }*/


                        doc.Close();
                    }
                }

                //After all of the PDF "stuff" above is done and closed but **before** we
                //close the MemoryStream, grab all of the active bytes from the stream
                bytes = ms.ToArray();
            }

            //Now we just need to do something with those bytes.
            //Here I'm writing them to disk but if you were in ASP.Net you might Response.BinaryWrite() them.
            //You could also write the bytes to a database in a varbinary() column (but please don't) or you
            //could pass them to another function for further PDF processing.
            var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test1.pdf");
            System.IO.File.WriteAllBytes(testFile, bytes);
        }

        private void sendmail()
        {
            /*
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("FromMailAddress");
                message.To.Add(new MailAddress("ToMailAddress"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
            */

            //string fromEmail = "harshy.167@gmail.com"//ConfigurationManager.AppSettings["fromEmail"].ToString();
            //MailMessage mm = new MailMessage();
            //mm.To.Add("recipientaddress");
            //mm.From = new MailAddress(fromEmail);
            //mm.Subject = "Online Request";
            //mm.Body = "Thanks for your time, Please find the attached invoice";
            //mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Invoice.pdf"));
            //mm.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();
            //smtp.EnableSsl = false;
            //NetworkCredential NetworkCred = new NetworkCredential();
            //NetworkCred.UserName = "info@email.com";
            //NetworkCred.Password = "email_password";
            //smtp.UseDefaultCredentials = true;
            //smtp.Credentials = NetworkCred;
            //smtp.Port = 25;
            //smtp.Send(mm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mshtml.HTMLDocument CurrentDocument = (mshtml.HTMLDocument)webBrowser1.Document.DomDocument;
            //mshtml.IHTMLStyleSheet styleSheet = CurrentDocument.createStyleSheet("", 0);
            //StreamReader streamReader = new StreamReader(@"..\browser.css"); //browser.css is Stylesheet file
            //string text = streamReader.ReadToEnd();
            //streamReader.Close();

            //styleSheet.cssText = text;

            //webBrowser1.DocumentText = html;
            //webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;

            



            browser.LoadHtml(html);
            this.Controls.Add(browser);
            //browser.Print();

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //var browser = webBrowser1.ActiveXInstance as SHDocVw.InternetExplorer;
            //browser.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVW.OLECMDID.OLECMDEXECOPT_DODEFAULT, 50,IntPtr.Zero);
            webBrowser1.Document.Body.Style = "zoom:70%";
            add();
        }

        private void add()
        {
            try
            {
                if (webBrowser1.Document != null)
                {
                    //IHTMLDocument2 currentDocument = (IHTMLDocument2)webBrowser1.Document.DomDocument;

                    //int length = currentDocument.styleSheets.length;
                    //IHTMLStyleSheet styleSheet = currentDocument.createStyleSheet(@"", length + 1);
                    //length = currentDocument.styleSheets.length;
                    //styleSheet.addRule("body", "background-color:blue");
                    TextReader reader = new StreamReader(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "C:\\Users\\acer\\Desktop\\css.css"));
                    string style = reader.ReadToEnd();
                    //styleSheet.cssText = style;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //browser.PrintToPdfAsync("C:\\Users\\acer\\Desktop\\h.pdf");
            //browser.Print();
            //generatePDF2();
            //Generate();
        }

        public void generatePDF()
        {
            //ConverterProperties prop = new ConverterProperties();
            //HtmlConverter.ConvertToPdf(html, File.Open("D:\\output.pdf", FileMode.Create), prop); 
            //var doc = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf("Your html in a string", PdfSharp.PageSize.A4);
            //PdfSharp.Pdf.PdfPage page = new PdfSharp.Pdf.PdfPage();
            //XImage img = XImage.FromGdiPlusImage(bitmap);
            //doc.Pages.Add(page);
            //XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
            //xgr.DrawImage(img, 0, 0);
            //doc.Save("D:\\ttyt.pdf"));
            //doc.Close();

            Bitmap bitmap = new Bitmap(790, 1800);
            Graphics g = Graphics.FromImage(bitmap);
            XGraphics xg = XGraphics.FromGraphics(g, new XSize(bitmap.Width, bitmap.Height));
            TheArtOfDev.HtmlRenderer.PdfSharp.HtmlContainer c = new TheArtOfDev.HtmlRenderer.PdfSharp.HtmlContainer();
            c.SetHtml(html);

            PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument();
            PdfSharp.Pdf.PdfPage page = new PdfSharp.Pdf.PdfPage();
            XImage img = XImage.FromGdiPlusImage(bitmap);
            pdf.Pages.Add(page);
            XGraphics xgr = XGraphics.FromPdfPage(pdf.Pages[0]);
            c.PerformLayout(xgr);
            c.PerformPaint(xgr);
            xgr.DrawImage(img, 0, 0);
            pdf.Save("D:\\ttttttest.pdf");
        }

        private void generatePDF2()
        {
            
            try

            {

                string strHtml = html;

                //string htmlFileName = Server.MapPath("~") + "\\files\\" + "ConvertHTMLToPDF.htm";

                //string pdfFileName = Request.PhysicalApplicationPath + "\\files\\" + "ConvertHTMLToPDF.pdf";

                string pdfFileName = "D:\\ccococoococ.pdf";

                //FileStream fsHTMLDocument = new FileStream(htmlFileName, FileMode.Open, FileAccess.Read);

                //StreamReader srHTMLDocument = new StreamReader(fsHTMLDocument);

                //strHtml = srHTMLDocument.ReadToEnd();

                //srHTMLDocument.Close();

                strHtml = strHtml.Replace("\r\n", "");

                strHtml = strHtml.Replace("\0", "");

                using (Stream fs = new FileStream(pdfFileName, FileMode.Create))

                {

                    using (Document doc = new Document(iTextSharp.text.PageSize.A4))

                    {

                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                        doc.Open();

                        using (StringReader sr = new StringReader(strHtml))

                        {

                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);

                        }

                        doc.Close();

                        //HttpContext.Current.Response.Clear();

                        HttpContext.Current.Response.ContentType = "application/pdf";

                        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=sample.pdf");

                        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

                        HttpContext.Current.Response.Write(doc);

                    }

                }

            }

            catch (Exception ex)

            {

                HttpContext.Current.Response.Write(ex.Message);

            }
            }
        private void Generate()
        {
            //try
            //{
                //IronPdf.Installation.DefaultRenderingEngine = IronPdf.Rendering.PdfRenderingEngine.Chrome;
                //var Renderer = new IronPdf.ChromePdfRenderer();
                //ChromePdfRenderer Renderer = new ChromePdfRenderer();
                //Renderer.RenderingOptions.FitToPaper = true;
                //Renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Screen;
                //Renderer.RenderingOptions.PrintHtmlBackgrounds = true;
                //Renderer.RenderingOptions.CreatePdfFormsFromHtml = true;
                //var doc = Renderer.RenderHtmlAsPdf("<h1>Hello world!</h1>");
                //var doc = Renderer.RenderUrlAsPdf("https://www.google.com/");
                //var doc = Renderer.RenderHtmlFileAsPdf("example.html");
                //doc.SaveAs("google_chrome.pdf");
                //var PDF = Renderer.RenderHtmlAsPdf("<h1>Hello IronPdf</h1>");
                //var OutputPath = "D:\\pixel-perfect.pdf";
                //PDF.SaveAs(OutputPath);

                //ChromePdfRenderer Renderer = new ChromePdfRenderer();
                //Renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print;
                //Renderer.RenderingOptions.PrintHtmlBackgrounds = false;
                //Renderer.RenderingOptions.CreatePdfFormsFromHtml = false;
                //var doc = Renderer.RenderUrlAsPdf("https://www.google.com/");
            //}
            //catch (IronPdf.Exceptions.IronPdfProductException e)
            //{
            //    MessageBox.Show(e.ToString());
            //}
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ETC_Load(object sender, EventArgs e)
        {
            //Generate();

        }
    }
}