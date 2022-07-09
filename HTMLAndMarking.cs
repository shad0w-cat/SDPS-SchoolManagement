using SDSP.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDSP
{
    class HTMLAndMarking
    {
        string htmlStringName, css, fa1, fa2, fa3, fa4, sa1, sa2, annual;
        string imageLocation;
        string studentName, fName, mName, dob, section;
        int className, admNo, attendance, totalDays;
        public HTMLAndMarking()
        {
            InitializeComponent();
        }

        public HTMLAndMarking(string examName)
        {
            imageLocation = Base64Encoded(Resources.Logo);
            htmlStringName = examName;
            InitializeComponent();
        }

        public static String Base64Encoded(System.Drawing.Image image)
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, ImageFormat.Jpeg);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public void InitializeComponent()
        {
            css = @"/*div {
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

                    label {
                        font-size: smaller;
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

                    .width-of-suject {
                        width: 20%;
                    }

                    .signature {
                        width: 100%;
                    }

                    .teacher-sign {
                        float: left;
                    }

                    .hos-sign {
                        float: right;
                    }


                    /* -------------------------------------------------------------------*/


                    /*                              TABLES                                */


                    /* -------------------------------------------------------------------*/

                    table {
                        width: 100%;
                        table-layout: fixed;
                        border: 2px solid black;
                        border-collapse: collapse;
                    }

                    .student-info-table {
                        width: 100%;
                        table-layout: fixed;
                        border-collapse: collapse;
                    }

                    .main-marks-table {
                        width: 100%;
                        table-layout: fixed;
                        border-collapse: collapse;
                    }

                    .table-csa {
                        width: auto;
                    }

                    .csa1-table {
                        float: left;
                        width: auto;
                    }

                    .csa2-table {
                        width: auto;
                        float: right;
                    }

                    .csa {
                        margin: auto;
                    }


                    /* -------------------------------------------------------------------*/


                    /*                              TABLES  END                           */


                    /* -------------------------------------------------------------------*/


                    /* -------------------------------------------------------------------*/


                    /*                              TD TR TH                              */


                    /* -------------------------------------------------------------------*/

                    td {
                        background-color: #D5F3FE;
                        border: 1px solid black;
                    }

                    th {
                        background-color: #70C8FF;
                        color: white;
                        border: 2px solid black;
                    }

                    table tr:nth-child(2) td,
                    table tr:last-child td {
                        border-top: 2px solid black;
                    }

                    #no-br-tb td {
                        border-top: 1px solid black;
                    }

                    .student-info-table td,
                    .student-info-table th {
                        color: #000;
                        text-align: left;
                        padding: 5px 0px 5px 10px;
                    }

                    .main-marks-table td,
                    .main-marks-table th {
                        padding: 5px;
                        text-align: center;
                    }


                    /*.main-marks-table td:first-child,
                    .main-marks-table th:first-child {
                        border-right: 1px solid black;;
                    }*/

                    .table-csa td:first-child,
                    .table-csa th:first-child {
                        padding: 5px 50px 5px 10px;
                    }

                    .table-csa td,
                    .table-csa th {
                        padding: 5px 10px;
                    }

                    .csa1-table td:last-child,
                    .csa2-table td:last-child {
                        text-align: center;
                    }


                    /* -------------------------------------------------------------------*/


                    /*                          TD TR TH  END                             */


                    /* -------------------------------------------------------------------*/";
            fa1 = @"<html>

                    <head>
                        <meta http-equiv='content-type' content='text/html; charset=utf-8' />

                        <title></title>
                        <style>
                    "
                        +
                            css
                        +
                        @"    </style>
                    </head>

                    <body>
                        <img src='data:image/jpeg;base64," + imageLocation +  @"' class='logo' alt='' />
                        <h1 class='school-name'>SUSHILA DEVI PUBLIC SCHOOL</h1>
                        <h3 class='school-name'>B-68, YADAV NAGAR, SAMEYPUR, DELHI-110042</h3>
                        <h3 class='school-name'>Performance Report</h3>

                        <br />
                        <br />
                        <br />

                        <div>
                            <div style='float: left'>Student Information</div>
                            <div style='text-align: right'>SESSION:</div>
                        </div>

                        <br />
                        <br />

                        <div class='student-info-div'>
                            <table class='student-info-table' cellpadding='3px' cellspacing='3px'>
                                <tr>
                                    <th>NAME:</th>
                                    <td>" + studentName + @"</td>
                                    <th>ADMISSION NUMBER:</th>
                                    <td>" + admNo + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>FATHER'S NAME:</th>
                                    <td>" + fName + @"</td>
                                    <th>CLASS:</th>
                                    <td>" + className + @"</td>
                                </tr>
                                <tr>
                                    <th>MOTHER'S NAME</th>
                                    <td>" + mName + @"</td>
                                    <th>SECTION:</th>
                                    <td>" + section + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>D.O.B:</th>
                                    <td>" + dob + @"</td>
                                    <th>ATTENDANCE:</th>
                                    <td>" + attendance + " of " + totalDays  + @"</td>
                                </tr>
                            </table>
                        </div>

                        <br />
                        <br />

                        <div class='main-marks-div'>
                            <table class='main-marks-table'>
                                <caption>
                                    FORMATIVE ASSESSMENT I
                                </caption>
                                <tr>
                                    <th>SUBJECT</th>
                                    <th>FA1 <br /><label>(MM10)</label></th>
                                    <th>PERCENTAGE</th>
                                </tr>
                                <tr>
                                    <td class='sub-name'>ENGLISH</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>HINDI</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>MATHEMATICS</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <!--col span=1 class='width-of-suject' /-->
                                    <td class='sub-name'>SOCIAL STUDIES</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>SCIENCE</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>TOTAL</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>

                        <br />

                        <div class='' style='
                            width: 100%;
                            text-align: right;
                            font-weight: bold;
                            font-size: larger;
                            '>
                            PERCENTAGE: %
                        </div>

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                        <div class='signature'>
                            <div class='teacher-sign'>Class Teacher's Signature</div>
                            <div class='hos-sign'>HOS's Signature</div>
                        </div>
                    </body>

                    </html>";
            fa2 = @"<html>

                    <head>
                        <meta http-equiv='content-type' content='text/html; charset=utf-8' />

                        <title></title>
                        <style>
                            "
                                +
                                    css
                                +
                                @"    </style>
                    </head>

                    <body>
                        <img src='data:image/jpeg;base64," + imageLocation +  @"' class='logo' alt='' />
                        <h1 class='school-name'>SUSHILA DEVI PUBLIC SCHOOL</h1>
                        <h3 class='school-name'>B-68, YADAV NAGAR, SAMEYPUR, DELHI-110042</h3>
                        <h3 class='school-name'>Performance Report</h3>

                        <br />
                        <br />
                        <br />

                        <div>
                            <div style='float: left'>Student Information</div>
                            <div style='text-align: right'>SESSION:</div>
                        </div>

                        <br />
                        <br />

                        <div class='student-info-div'>
                            <table class='student-info-table' cellpadding='3px' cellspacing='3px'>
                                <tr>
                                    <th>NAME:</th>
                                    <td>" + studentName + @"</td>
                                    <th>ADMISSION NUMBER:</th>
                                    <td>" + admNo + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>FATHER'S NAME:</th>
                                    <td>" + fName + @"</td>
                                    <th>CLASS:</th>
                                    <td>" + className + @"</td>
                                </tr>
                                <tr>
                                    <th>MOTHER'S NAME</th>
                                    <td>" + mName + @"</td>
                                    <th>SECTION:</th>
                                    <td>" + section + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>D.O.B:</th>
                                    <td>" + dob + @"</td>
                                    <th>ATTENDANCE:</th>
                                    <td>" + attendance + " of " + totalDays  + @"</td>
                                </tr>
                            </table>
                        </div>

                        <br />
                        <br />

                        <div class='main-marks-div'>
                            <table class='main-marks-table'>
                                <caption>
                                    FORMATIVE ASSESSMENT II
                                </caption>
                                <tr>
                                    <th>SUBJECT</th>
                                    <th>FA1 <br /><label>(MM10)</label></th>
                                    <th>FA2 <br /><label>(MM10)</label></th>
                                    <th>PERCENTAGE</th>
                                </tr>
                                <tr>
                                    <td class='sub-name'>ENGLISH</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>HINDI</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>MATHEMATICS</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <!--col span='1' class='width-of-suject' /-->
                                    <td class='sub-name'>SOCIAL STUDIES</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>SCIENCE</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>TOTAL</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>

                        <br />

                        <div class='' style='
                            width: 100%;
                            text-align: right;
                            font-weight: bold;
                            font-size: larger;
                            '>
                            PERCENTAGE: %
                        </div>

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                        <div class='signature'>
                            <div class='teacher-sign'>Class Teacher's Signature</div>
                            <div class='hos-sign'>HOS's Signature</div>
                        </div>
                    </body>

                    </html>";
            fa3 = @"<html>

                    <head>
                        <meta http-equiv='content-type' content='text/html; charset=utf-8' />

                        <title></title>
                        <style>
                            "
                                +
                                    css
                                +
                                @"    </style>
                    </head>

                    <body>
                        <img src='data:image/jpeg;base64," + imageLocation +  @"' class='logo' alt='' />
                        <h1 class='school-name'>SUSHILA DEVI PUBLIC SCHOOL</h1>
                        <h3 class='school-name'>B-68, YADAV NAGAR, SAMEYPUR, DELHI-110042</h3>
                        <h3 class='school-name'>Performance Report</h3>

                        <br />
                        <br />
                        <br />

                        <div>
                            <div style='float: left'>Student Information</div>
                            <div style='text-align: right'>SESSION:</div>
                        </div>

                        <br />
                        <br />

                        <div class='student-info-div'>
                            <table class='student-info-table' cellpadding='3px' cellspacing='3px'>
                                <tr>
                                    <th>NAME:</th>
                                    <td>" + studentName + @"</td>
                                    <th>ADMISSION NUMBER:</th>
                                    <td>" + admNo + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>FATHER'S NAME:</th>
                                    <td>" + fName + @"</td>
                                    <th>CLASS:</th>
                                    <td>" + className + @"</td>
                                </tr>
                                <tr>
                                    <th>MOTHER'S NAME</th>
                                    <td>" + mName + @"</td>
                                    <th>SECTION:</th>
                                    <td>" + section + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>D.O.B:</th>
                                    <td>" + dob + @"</td>
                                    <th>ATTENDANCE:</th>
                                    <td>" + attendance + " of " + totalDays  + @"</td>
                                </tr>
                            </table>
                        </div>

                        <br />
                        <br />

                        <div class='main-marks-div'>
                            <table class='main-marks-table'>
                                <caption>
                                    FORMATIVE ASSESSMENT III
                                </caption>
                                <tr>
                                    <th>SUBJECT</th>
                                    <th>FA1 <br /><label>(MM10)</label></th>
                                    <th>FA2 <br /><label>(MM10)</label></th>
                                    <th>FA3 <br /><label>(MM10)</label></th>
                                    <th>PERCENTAGE</th>
                                </tr>
                                <tr>
                                    <td class='sub-name'>ENGLISH</td>
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
                                </tr>
                                <tr>
                                    <td class='sub-name'>MATHEMATICS</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <!--col span=1 class='width-of-suject' /-->
                                    <td class='sub-name'>SOCIAL STUDIES</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <td class='sub-name'>SCIENCE</td>
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
                                </tr>
                            </table>
                        </div>

                        <br />

                        <div class='' style='
                            width: 100%;
                            text-align: right;
                            font-weight: bold;
                            font-size: larger;
                            '>
                            PERCENTAGE: %
                        </div>

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                        <div class='signature'>
                            <div class='teacher-sign'>Class Teacher's Signature</div>
                            <div class='hos-sign'>HOS's Signature</div>
                        </div>
                    </body>

                    </html>";
            fa4 = @"<html>

                    <head>
                        <meta http-equiv='content-type' content='text/html; charset=utf-8' />

                        <title></title>
                        <style>
                            "
                                +
                                    css
                                +
                                @"    </style>
                    </head>

                    <body>
                        <img src='data:image/jpeg;base64," + imageLocation +  @"' class='logo' alt='' />
                        <h1 class='school-name'>SUSHILA DEVI PUBLIC SCHOOL</h1>
                        <h3 class='school-name'>B-68, YADAV NAGAR, SAMEYPUR, DELHI-110042</h3>
                        <h3 class='school-name'>Performance Report</h3>

                        <br />
                        <br />
                        <br />

                        <div>
                            <div style='float: left'>Student Information</div>
                            <div style='text-align: right'>SESSION:</div>
                        </div>

                        <br />
                        <br />

                        <div class='student-info-div'>
                            <table class='student-info-table' cellpadding='3px' cellspacing='3px'>
                                <tr>
                                    <th>NAME:</th>
                                    <td>" + studentName + @"</td>
                                    <th>ADMISSION NUMBER:</th>
                                    <td>" + admNo + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>FATHER'S NAME:</th>
                                    <td>" + fName + @"</td>
                                    <th>CLASS:</th>
                                    <td>" + className + @"</td>
                                </tr>
                                <tr>
                                    <th>MOTHER'S NAME</th>
                                    <td>" + mName + @"</td>
                                    <th>SECTION:</th>
                                    <td>" + section + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>D.O.B:</th>
                                    <td>" + dob + @"</td>
                                    <th>ATTENDANCE:</th>
                                    <td>" + attendance + " of " + totalDays  + @"</td>
                                </tr>
                            </table>
                        </div>

                        <br />
                        <br />

                        <div class='main-marks-div'>
                            <table class='main-marks-table'>
                                <caption>
                                    FORMATIVE ASSESSMENT IV
                                </caption>
                                <tr>
                                    <th>SUBJECT</th>
                                    <th>FA1 <br /><label>(MM10)</label></th>
                                    <th>FA2 <br /><label>(MM10)</label></th>
                                    <th>FA3 <br /><label>(MM10)</label></th>
                                    <th>FA4 <br /><label>(MM10)</label></th>
                                    <th>PERCENTAGE</th>
                                </tr>
                                <tr>
                                    <td class='sub-name'>ENGLISH</td>
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
                                </tr>
                                <tr>
                                    <td class='sub-name'>MATHEMATICS</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <col span=1 class='width-of-suject' />
                                    <td class='sub-name'>SOCIAL STUDIES</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <td class='sub-name'>SCIENCE</td>
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
                                </tr>
                            </table>
                        </div>

                        <br />

                        <div class='' style='
                            width: 100%;
                            text-align: right;
                            font-weight: bold;
                            font-size: larger;
                            '>
                            PERCENTAGE: %
                        </div>

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                        <div class='signature'>
                            <div class='teacher-sign'>Class Teacher's Signature</div>
                            <div class='hos-sign'>HOS's Signature</div>
                        </div>
                    </body>

                    </html>";
            sa1 = @"<html>

                    <head>
                        <meta http-equiv='content-type' content='text/html; charset=utf-8' />

                        <title></title>
                        <style>
                            "
                                +
                                    css
                                +
                                @"    </style>
                    </head>

                    <body>
                        <img src='data:image/jpeg;base64," + imageLocation +  @"' class='logo' alt='' />
                        <h1 class='school-name'>SUSHILA DEVI PUBLIC SCHOOL</h1>
                        <h3 class='school-name'>B-68, YADAV NAGAR, SAMEYPUR, DELHI-110042</h3>
                        <h3 class='school-name'>Performance Report</h3>

                        <br />
                        <br />
                        <br />

                        <div>
                            <div style='float: left'>Student Information</div>
                            <div style='text-align: right'>SESSION:</div>
                        </div>

                        <br />
                        <br />

                        <div class='student-info-div'>
                            <table class='student-info-table' cellpadding='3px' cellspacing='3px'>
                                <tr>
                                    <th>NAME:</th>
                                    <td>" + studentName + @"</td>
                                    <th>ADMISSION NUMBER:</th>
                                    <td>" + admNo + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>FATHER'S NAME:</th>
                                    <td>" + fName + @"</td>
                                    <th>CLASS:</th>
                                    <td>" + className + @"</td>
                                </tr>
                                <tr>
                                    <th>MOTHER'S NAME</th>
                                    <td>" + mName + @"</td>
                                    <th>SECTION:</th>
                                    <td>" + section + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>D.O.B:</th>
                                    <td>" + dob + @"</td>
                                    <th>ATTENDANCE:</th>
                                    <td>" + attendance + " of " + totalDays  + @"</td>
                                </tr>
                            </table>
                        </div>

                        <br />
                        <br />

                        <div class='main-marks-div'>
                            <table class='main-marks-table'>
                                <caption>
                                    PART-I(A) SUMMATIVE ASSESSMENT I
                                </caption>
                                <tr>
                                    <th>SUBJECT</th>
                                    <th>SA1 <br /><label>(MM20)</label></th>
                                    <th>PERCENTAGE</th>
                                </tr>
                                <tr>
                                    <td class='sub-name'>ENGLISH</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>HINDI</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>MATHEMATICS</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <!--col span=1 class='width-of-suject' /-->
                                    <td class='sub-name'>SOCIAL STUDIES</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>SCIENCE</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>TOTAL</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>

                        <br />

                        <div class='' style='
                            width: 100%;
                            text-align: right;
                            font-weight: bold;
                            font-size: larger;
                            '>
                            PERCENTAGE: %
                        </div>

                        <br />
                        <br />

                        <div class='csa-div' style='width: auto;'>
                            <table class='table-csa csa'>
                                <caption>
                                    PART-I(B) SCHOLASTIC ACHIEVEMENTS
                                </caption>
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

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                        <div class='signature'>
                            <div class='teacher-sign'>Class Teacher's Signature</div>
                            <div class='hos-sign'>HOS's Signature</div>
                        </div>
                    </body>

                    </html>";
            sa2 = @"<html>

                    <head>
                        <meta http-equiv='content-type' content='text/html; charset=utf-8' />

                        <title></title>
                        <style>
                            "
                                +
                                    css
                                +
                                @"    </style>
                    </head>

                    <body>
                        <img src='data:image/jpeg;base64," + imageLocation +  @"' class='logo' alt='' />
                        <h1 class='school-name'>SUSHILA DEVI PUBLIC SCHOOL</h1>
                        <h3 class='school-name'>B-68, YADAV NAGAR, SAMEYPUR, DELHI-110042</h3>
                        <h3 class='school-name'>Performance Report</h3>

                        <br />
                        <br />
                        <br />

                        <div>
                            <div style='float: left'>Student Information</div>
                            <div style='text-align: right'>SESSION:</div>
                        </div>

                        <br />
                        <br />

                        <div class='student-info-div'>
                            <table class='student-info-table' cellpadding='3px' cellspacing='3px'>
                                <tr>
                                    <th>NAME:</th>
                                    <td>" + studentName + @"</td>
                                    <th>ADMISSION NUMBER:</th>
                                    <td>" + admNo + @"</td>
                                </tr>
                                <tr id='no-br-tb' s>
                                    <th>FATHER'S NAME:</th>
                                    <td>" + fName + @"</td>
                                    <th>CLASS:</th>
                                    <td>" + className + @"</td>
                                </tr>
                                <tr>
                                    <th>MOTHER'S NAME</th>
                                    <td>" + mName + @"</td>
                                    <th>SECTION:</th>
                                    <td>" + section + @"</td>
                                </tr>
                                <tr id='no-br-tb'>
                                    <th>D.O.B:</th>
                                    <td>" + dob + @"</td>
                                    <th>ATTENDANCE:</th>
                                    <td>" + attendance + " of " + totalDays  + @"</td>
                                </tr>
                            </table>
                        </div>

                        <br />
                        <br />

                        <div class='main-marks-div'>
                            <table class='main-marks-table'>
                                <caption>
                                    PART-I(A) SUMMATIVE ASSESSMENT II
                                </caption>
                                <tr>
                                    <th>SUBJECT</th>
                                    <th>SA1 <br /><label>(MM20)</label></th>
                                    <th>SA2 <br /><label>(MM35)</label></th>
                                    <th>PERCENTAGE</th>
                                </tr>
                                <tr>
                                    <td class='sub-name'>ENGLISH</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>HINDI</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>MATHEMATICS</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <!--col span='1' class='width-of-suject' /-->
                                    <td class='sub-name'>SOCIAL STUDIES</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>SCIENCE</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class='sub-name'>TOTAL</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>

                        <br />

                        <div class='' style='
                            width: 100%;
                            text-align: right;
                            font-weight: bold;
                            font-size: larger;
                            '>
                            PERCENTAGE: %
                        </div>

                        <br />
                        <br />

                        <div class='csa-div' style='width: auto;'>
                            <table class='table-csa csa'>
                                <caption>
                                    PART-I(B) SCHOLASTIC ACHIEVEMENTS
                                </caption>
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

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                        <div class='signature'>
                            <div class='teacher-sign'>Class Teacher's Signature</div>
                            <div class='hos-sign'>HOS's Signature</div>
                        </div>
                    </body>

                    </html>";
            annual = @"<html>

                        <head>
                            <meta http-equiv='content-type' content='text/html; charset=utf-8' />

                            <title></title>
                            <style>
                                "
                                    +
                                        css
                                    +
                                    @"    </style>
                        </head>

                        <body>
                            <img src='data:image/jpeg;base64," + imageLocation +  @"' class='logo' alt='' />
                            <h1 class='school-name'>SUSHILA DEVI PUBLIC SCHOOL</h1>
                            <h3 class='school-name'>B-68, YADAV NAGAR, SAMEYPUR, DELHI-110042</h3>
                            <h3 class='school-name'>Annual Performance Report</h3>

                            <br />
                            <br />
                            <br />

                            <div>
                                <div style='float: left'>Student Information</div>
                                <div style='text-align: right'>SESSION:</div>
                            </div>

                            <br />
                            <br />

                            <div class='student-info-div'>
                                <table class='student-info-table' cellpadding='3px' cellspacing='3px'>
                                    <tr>
                                        <th>NAME:</th>
                                        <td>" + studentName + @"</td>
                                        <th>ADMISSION NUMBER:</th>
                                        <td>" + admNo + @"</td>
                                    </tr>
                                    <tr id='no-br-tb'>
                                        <th>FATHER'S NAME:</th>
                                        <td>" + fName + @"</td>
                                        <th>CLASS:</th>
                                        <td id='no-br-tb'>" + className + @"</td>
                                    </tr>
                                    <tr>
                                        <th>MOTHER'S NAME</th>
                                        <td>" + mName + @"</td>
                                        <th>SECTION:</th>
                                        <td>" + section + @"</td>
                                    </tr>
                                    <tr id='no-br-tb'>
                                        <th>D.O.B:</th>
                                        <td>" + dob + @"</td>
                                        <th>ATTENDANCE:</th>
                                        <td>" + attendance + " of " + totalDays  + @"</td>
                                    </tr>
                                </table>
                            </div>

                            <br />
                            <br />

                            <div class='main-marks-div'>
                                <table class='main-marks-table'>
                                    <caption>
                                        PART-I(A) ACADEMIC PERFORMANCE(SCHOLASTIC AREA)
                                    </caption>
                                    <tr>
                                        <th>SUBJECT</th>
                                        <th>FA1 <br /><label>(MM10)</label></th>
                                        <th>FA2 <br /><label>(MM10)</label></th>
                                        <th>SA1 <br /><label>(MM20)</label></th>
                                        <th>FA3 <br /><label>(MM10)</label></th>
                                        <th>FA4 <br /><label>(MM10)</label></th>
                                        <th>SA2 <br /><label>(MM35)</label></th>
                                        <th style='word-wrap: break-word'>
                                            ATTENDANCE <br /><label>(MM5)</label>
                                        </th>
                                        <th>GRAND TOTAL <br /><label>(MM100)</label></th>
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
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class='sub-name'>MATHEMATICS</td>
                                        <td></td>
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
                                        <col span='1' class='width-of-suject' />
                                        <td class='sub-name'>SOCIAL STUDIES</td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr id='no-br-tb'>
                                        <td class='sub-name'>SCIENCE</td>
                                        <td></td>
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
                                        <td></td>
                                    </tr>
                                </table>
                            </div>

                            <br />

                            <div class='' style='
                                width: 100%;
                                text-align: right;
                                font-weight: bold;
                                font-size: larger;
                                '>
                                PERCENTAGE: %
                            </div>

                            <br />
                            <br />

                            <div class='table-csa-div' style='width: 100%'>
                                <div class='csa1-div' style='float: left'>
                                    <table class='table-csa csa1-table'>
                                        <caption>
                                            PART-I(B) SCHOLASTIC ACHIEVEMENTS
                                        </caption>
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
                                <div class='csa2-div' style='float: right; width: auto'>
                                    <table class='table-csa csa2-table'>
                                        <caption>
                                            PART-II CO-SCHOLASTIC ACHIEVEMENTS
                                        </caption>
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

                            <div style='clear: both'></div>

                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />

                            <div class='signature'>
                                <div class='teacher-sign'>Class Teacher's Signature</div>
                                <div class='hos-sign'>HOS's Signature</div>
                            </div>
                        </body>

                        </html>";
        }


        public string getHTMLCode()
        {
            if (htmlStringName == "FA1")
            {
                return fa1;
            }
            else if (htmlStringName == "FA2")
            {
                return fa2;
            }
            else if (htmlStringName == "FA3")
            {
                return fa3;
            }
            else if (htmlStringName == "FA4")
            {
                return fa4;
            }
            else if (htmlStringName == "SA1")
            {
                return sa1;
            }
            else if (htmlStringName == "SA2")
            {
                return sa2;
            }
            else if (htmlStringName == "Annual")
            {
                return annual;
            }
            else
            {
                return "Wrong Exam Name Provided";
            }

        }
    }
}
