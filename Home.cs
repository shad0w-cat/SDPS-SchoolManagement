using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ComponentFactory.Krypton.Toolkit;
using System.Text.RegularExpressions;

namespace SDSP
{
    public partial class Home : Form
    {
        int lvl;
        string connectionString = @"Data Source = . ; Initial Catalog = SDPS ; Integrated Security = Yes ;";

        public Home()
        {
            InitializeComponent();
            //MessageBox.Show(int.Parse("123").ToString());
        }

        public Home(int level)
        {
            InitializeComponent();
            lvl = level;
            //MessageBox.Show(lvl.ToString());
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (lvl == 2)
            {
                hideMenuFromTeachers();
            }
            // SQL Connection
            //SQLConnectionFunction();
            setMaxDate(DateTime.Now);
            roundCorners();
            hideSubMenuPanel();
            hideTabPages();
            logoPanel.Height = 300;
            //studentMenuTab.Appearance = TabAppearance.FlatButtons;
            studentMenuTab.ItemSize = new Size(0, 1);
            studentMenuTab.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in studentMenuTab.TabPages)
            {
                tab.Text = "";
            }
        }

        /// <summary>
        /// Create New Session only if the year matches for the session to be created not earlier
        /// </summary>
        /// <param name="currentSession"></param>
        /// 

        private int getCurrentSessionYear()
        {
            string sessionId = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //string commandString = "SELECT name FROM SDPS.sys.Tables where name LIKE 'Class%';";
                string commandString = "SELECT SessionID FROM Session WHERE CurrentSession = 1";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                SqlDataReader execute = sqlCommand.ExecuteReader();
                while (execute.Read())
                {
                    sessionId = execute[0].ToString();
                }

                //tableName = string.Join("", tableName.ToCharArray().Where(Char.IsDigit));
                sqlConnection.Close();
            }
            //System.Text.RegularExpressions.Regex
            //resultString = Regex.Match(subjectString, @"\d+").Value;
            //string numericPhone = new String(phone.Where(Char.IsDigit).ToArray());
            if (sessionId == null || sessionId == "")
            {
                MessageBox.Show("Error 32! Contact System Administrator.");
                return 0;
            }
            else
                return int.Parse(sessionId);
        }

        private void createNewSession()
        {
            int currentSession = getCurrentSessionYear();
            if (DateTime.Now.Year <= currentSession)
            {
                DialogResult option = MessageBox.Show("New Session Cannot Be Added as old session have to be completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int newSession = currentSession + 1;
                string[] tables = { "Class", "Exams", "Marks", "Grade" };
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string commandString;
                    sqlConnection.Open();
                    foreach (string tableName in tables)
                    {
                        if (tableName == "Class")
                        {
                            commandString = "SELECT * INTO " + (tableName + newSession.ToString()) + " FROM " + (tableName + currentSession.ToString()) + " WHERE Class != 5;\n" +
                                            "UPDATE " + (tableName + newSession.ToString()) + " SET Class = Class + 1;\n";
                        }
                        else
                        {
                            commandString = @"SELECT TOP 0 * INTO " + (tableName + newSession.ToString()) + " FROM " + (tableName + currentSession.ToString()) + ";\n";
                        }
                        MessageBox.Show(commandString);

                        using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                        {
                            sqlCommand.ExecuteNonQuery();
                            //sqlCommand.Parameters.Clear();
                            //MessageBox.Show(x.ToString());
                        }

                    }

                    commandString = "UPDATE Session SET CurrentSession = 0 WHERE SessionID = @currSession;\n" +
                                    "INSERT INTO Session VALUES (" + newSession + ", " + (newSession + "-" + (newSession - 1999)) + ", 1);";
                    MessageBox.Show(commandString);

                    using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@currSession", currentSession.ToString());
                        sqlCommand.ExecuteNonQuery();
                        //MessageBox.Show(x.ToString());
                    }
                    sqlConnection.Close();
                }
            }

        }

        /// 
        /// ROUND CORNERS FOR IMAGE
        /// 
        private void roundCorners()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, logoPictureBox.Width, logoPictureBox.Height);
            logoPictureBox.Region = new Region(path);
        }

        /// <summary>
        /// HIDE ALL SUBMENU
        /// </summary>
        private void hideSubMenuPanel()
        {
            studentMenuPanel.Visible = false;
            examMenuPanel.Visible = false;
            adminMenuPanel.Visible = false;
        }

        private void hideTabPages()
        {
            studentMenuTab.Visible = false;
            addStudentTabPage.Hide();


        }

        private void hideMenuFromTeachers()
        {
            adminMenuButton.Visible = false;
            adminMenuPanel.Visible = false;
            studentMenuButton.Visible = false;
            studentMenuPanel.Visible = false;
        }

        private void studentMenuButton_Click(object sender, EventArgs e)
        {
            if (studentMenuPanel.Visible == false)
            {
                hideSubMenuPanel();
                studentMenuPanel.Visible = true;
            }
            else
                studentMenuPanel.Visible = false;
        }

        private void examMenuButton_Click(object sender, EventArgs e)
        {
            if (examMenuPanel.Visible == false)
            {
                hideSubMenuPanel();
                examMenuPanel.Visible = true;
            }
            else
                examMenuPanel.Visible = false;

        }

        private void adminMenuButton_Click(object sender, EventArgs e)
        {
            if (adminMenuPanel.Visible == false)
            {
                hideSubMenuPanel();
                adminMenuPanel.Visible = true;
            }
            else
                adminMenuPanel.Visible = false;
        }

        /// <summary>
        /// Clear All TEXT BOXES IN A GIVEN TABPAGE
        /// </summary>
        /// <param name="controlName"></param>
        private void ClearControls(Control controlName)
        {
            foreach (Control c in controlName.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                    //KryptonTextBox     Treated as a normal textbox
                }

                if (c.HasChildren)
                {
                    ClearControls(c);
                }


                if (c is CheckBox)
                {

                    ((CheckBox)c).Checked = false;
                }

                if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }

                if (c is ComboBox)
                {
                    ((ComboBox)c).ResetText();
                    //KryptonCheckBox     Treated as a normal checkbox
                }

                if (c is KryptonDateTimePicker)
                {
                    ((KryptonDateTimePicker)c).Value = DateTime.Now;
                    //KryptonDateTimePicker Not treated as normal DateTimePicker
                }

                if (c is KryptonComboBox)
                {
                    ((KryptonComboBox)c).SelectedIndex = -1;
                    //KryptonDateTimePicker Not treated as normal DateTimePicker
                }

                if (c is KryptonCheckBox)
                {
                    ((KryptonCheckBox)c).Checked = false;
                    //KryptonDateTimePicker Not treated as normal DateTimePicker
                }
            }
        }

        /// <summary>
        /// READ ONLY TEXT BOXES DATETIME PICKER AND COMBOBOX
        /// </summary>
        /// <param name="controlName"></param>
        private void ReadOnlyControls(Control controlName)
        {
            foreach (Control c in controlName.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = true;
                    //KryptonTextBox     Treated as a normal textbox
                }

                if (c.HasChildren)
                {
                    ReadOnlyControls(c);
                }
            }
        }



        private void addStudentTabPage_Click(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void setMaxDate(DateTime dateTime)
        {
            dobDateTimePickerA.MaxDate = dobDateTimePickerA.Value = dateTime;
            doaDateTimePickerA.MaxDate = doaDateTimePickerA.Value = dateTime;
            dobDateTimePickerM.MaxDate = dobDateTimePickerM.Value = dateTime;
            doaDateTimePickerM.MaxDate = doaDateTimePickerM.Value = dateTime;
        }

        /// <summary>
        /// Clear/Reset Buttons Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButtonA_Click(object sender, EventArgs e)
        {
            KryptonButton cntrl = (KryptonButton)sender;
            ClearControls(cntrl.Parent);
            //var control = this.Controls.Find(cntrl.Parent.Name, true);
            //String to control name
        }

        private void clearButtonD_Click(object sender, EventArgs e)
        {
            KryptonButton cntrl = (KryptonButton)sender;
            ClearControls(cntrl.Parent);
            //var control = this.Controls.Find(cntrl.Parent.Name, true);
            //String to control name
        }

        private void clearButtonM_Click(object sender, EventArgs e)
        {
            KryptonButton cntrl = (KryptonButton)sender;
            ClearControls(cntrl.Parent);
            //var control = this.Controls.Find(cntrl.Parent.Name, true);
            //String to control name
        }

        private void newSessionButton_Click(object sender, EventArgs e)
        {
            createNewSession();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            studentMenuTab.Visible = true;
            studentMenuTab.SelectedTab = addStudentTabPage;
        }

        private void delStudentButton_Click(object sender, EventArgs e)
        {
            studentMenuTab.Visible = true;
            ReadOnlyControls(deleteStudentTabPage);
            searchTextBoxD.ReadOnly = false;
            studentMenuTab.SelectedTab = deleteStudentTabPage;
            searchTextBoxD.Focus();
        }

        private void editStudentButton_Click(object sender, EventArgs e)
        {
            studentMenuTab.Visible = true;
            studentMenuTab.SelectedTab = modifyStudentTabPage;
            searchTextBoxM.Focus();

        }

        private void feesButton_Click(object sender, EventArgs e)
        {
            studentMenuTab.Visible = true;
            studentMenuTab.SelectedTab = feesTabPage;
        }

        //
        //
        // TEXTBOX VALIDATIONS
        //
        //

        private void textOnlyValidation (object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void numberOnlyValidation(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        //Validations

        private bool emailValidation (string controlNameString)
        {
            var controlName = this.Controls.Find(controlNameString, true);
            //if (Regex.IsMatch(controlName.Text,@"[A - z0 - 9] +@[A-z]+[.][A - z]")) 
            //    return true;
            return true;
        }

        private bool validationsCheck(Control controlName)
        {
            string[] notImpControlNames = {"email", "mobile", "aadhaar", "fAadhaar", "mAadhaar"};
            if (controlName.Name == "addStudentTabPage")
            {
                int i = 0;
                foreach (string control in notImpControlNames)
                {
                    notImpControlNames[i] = control + "TextBoxA";
                    i++;
                }
            }
            else
            {
                int i = 0;
                foreach (string control in notImpControlNames)
                {
                    notImpControlNames[i] = control + "TextBoxM";
                    i++;
                }
            }
            
            foreach (Control c in controlName.Controls)
            {
                if (c is KryptonTextBox)
                {

                    if (((KryptonTextBox)c).Text == "" && !notImpControlNames.Contains(c.Name))
                    {
                        //MessageBox.Show("Hello");
                        validationErrorProvider.SetError((KryptonTextBox)c, "Cannot be left empty!");
                    }

                    //KryptonTextBox     Treated as a normal textbox
                }

                if (c is KryptonDateTimePicker)
                {
                    if (((KryptonDateTimePicker)c).Value <= DateTime.Now);
                }

                if (c is KryptonComboBox)
                {
                    ((KryptonComboBox)c).SelectedIndex = -1;
                    //KryptonDateTimePicker Not treated as normal DateTimePicker
                }
            }
            Control email;

            //MessageBox.Show(email.Name);

            
            return false;
        }

        /*----------------------------------------------------------------------------------------------------*/
        /*---------------------------------    DELETE MODIFY SEARCH BUTTONS     ------------------------------*/
        /*----------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// SEARCH BUTTON FOR MODIFY PAGE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButtonM_Click(object sender, EventArgs e)
        {
            int currentSession = getCurrentSessionYear();
            int found = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    string commandStr = @"SELECT * FROM Student, Class" + currentSession + " WHERE AdmissionNo = @admNo and Student.AdmissionNo = Class" + currentSession + ".AdmNo";
                    //MessageBox.Show(commandStr);
                    using (SqlCommand sqlCommand = new SqlCommand(commandStr, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@admNo", int.Parse(searchTextBoxM.Text));
                        SqlDataReader data = sqlCommand.ExecuteReader();
                        while (data.Read())
                        {
                            studentNameTextBoxM.Text = data["Name"].ToString();
                            fNameTextBoxM.Text = data["FName"].ToString();
                            mNameTextBoxM.Text = data["MName"].ToString();

                            aadhaarTextBoxM.Text = data["Aadhaar"].ToString();
                            fAadhaarTextBoxM.Text = data["FAadhaar"].ToString();
                            mAadhaarTextBoxM.Text = data["MAadhaar"].ToString();

                            fProfessionTextBoxM.Text = data["FProfession"].ToString();
                            mProfessionTextBoxM.Text = data["MProfession"].ToString();

                            socialCategoryComboBoxM.Text = data["SocialCategory"].ToString();
                            religionComboBoxM.Text = data["Religion"].ToString();

                            genderComboBoxM.Text = data["Gender"].ToString();

                            admissionNoTextBoxM.Text = data["AdmissionNo"].ToString();

                            doaDateTimePickerM.Value = DateTime.Parse(data["DOA"].ToString());
                            dobDateTimePickerM.Value = DateTime.Parse(data["DOB"].ToString());

                            emailTextBoxM.Text = data["Email"].ToString();
                            mobileTextBoxM.Text = data["PhoneNumber"].ToString();

                            addressTextBoxM.Text = data["Address"].ToString();

                            ewsCheckBoxM.Checked = Boolean.Parse(data["EWS"].ToString());
                            dgCheckBoxM.Checked = Boolean.Parse(data["DG"].ToString());

                            classTextBoxM.Text = data["Class"].ToString();
                            sectionTextBoxM.Text = data["Sec"].ToString();
                            found = 1;
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                sqlConnection.Close();
            }

            if (found == 0)
            {
                recordNotFoundLabelM.Visible = true;
                clearButtonM.PerformClick();
            }
        }

        /// <summary>
        /// SEARCH BUTTON FOR DELETE PAGE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButtonD_Click(object sender, EventArgs e)
        {
            int currentSession = getCurrentSessionYear();
            int found = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    string commandStr = @"SELECT * FROM Student, Class" + currentSession + " WHERE AdmissionNo = @admNo and Student.AdmissionNo = Class" + currentSession + ".AdmNo";
                    using (SqlCommand sqlCommand = new SqlCommand(commandStr, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@admNo", int.Parse(searchTextBoxD.Text));
                        SqlDataReader data = sqlCommand.ExecuteReader();
                        while (data.Read())
                        {
                            studentNameTextBoxD.Text = data["Name"].ToString();
                            fNameTextBoxD.Text = data["FName"].ToString();
                            mNameTextBoxD.Text = data["MName"].ToString();

                            aadhaarTextBoxD.Text = data["Aadhaar"].ToString();
                            fAadhaarTextBoxD.Text = data["FAadhaar"].ToString();
                            mAadhaarTextBoxD.Text = data["MAadhaar"].ToString();

                            fProfessionTextBoxD.Text = data["FProfession"].ToString();
                            mProfessionTextBoxD.Text = data["MProfession"].ToString();

                            socialCategoryTextBoxD.Text = data["SocialCategory"].ToString();
                            religionTextBoxD.Text = data["Religion"].ToString();

                            genderTextBoxD.Text = data["Gender"].ToString();

                            admissionNoTextBoxD.Text = data["AdmissionNo"].ToString();

                            var doa = DateTime.Parse(data["DOA"].ToString());
                            var dob = DateTime.Parse(data["DOB"].ToString());
                            doaTextBoxD.Text = doa.ToString("dd-MM-yyyy");
                            dobTextBoxD.Text = dob.ToString("dd-MM-yyyy");

                            emailTextBoxD.Text = data["Email"].ToString();
                            mobileTextBoxD.Text = data["name"].ToString();

                            addressTextBoxD.Text = data["name"].ToString();

                            classTextBoxD.Text = data["Class"].ToString();
                            sectionTextBoxD.Text = data["Sec"].ToString();
                            found = 1;
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                sqlConnection.Close();
            }

            if (found == 0)
            {
                recordNotFoundLabelD.Visible = true;
                clearButtonD.PerformClick();
            }
        }

        /*----------------------------------------------------------------------------------------------------*/
        /*----------------------------------    SAVE DELETE MODIFY BUTTONS    --------------------------------*/
        /*----------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// SAVE BUTTON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Creating Button Object of Control Type
            KryptonButton ctrl = (KryptonButton)sender;

            // Sending Button Object Parent and Checking for Validations 
            if (/*validationsCheck(ctrl.Parent) ==*/ true)
            {
                int currentSession = getCurrentSessionYear();
                // If validation conditions are met then save in database 
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    try
                    {
                        var name = studentNameTextBoxA.Text;
                        string commandStr = @"INSERT INTO Student VALUES ( @admNo, @sName, @aadhaar, @gender, @dob, @doa, @fName, @fAadhaar, @fProfession, @mName, @mAadhaar, @mProfession, @phoneNo, @email, @socialCategory, @religion, @ews, @dg, @address);
                                              INSERT INTO Class" + currentSession + " (AdmNo, Class, Sec) VALUES ( @admNo, @class, @section);";
                        MessageBox.Show(commandStr);
                        using (SqlCommand sqlCommand = new SqlCommand(commandStr, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@admNo", int.Parse(admissionNoTextBoxA.Text));
                            sqlCommand.Parameters.AddWithValue("@sName", name);
                            sqlCommand.Parameters.AddWithValue("@aadhaar", aadhaarTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@gender", genderComboBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@dob", dobDateTimePickerA.Value.Date);
                            sqlCommand.Parameters.AddWithValue("@doa", doaDateTimePickerA.Value.Date);
                            sqlCommand.Parameters.AddWithValue("@fName", fNameTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@fAadhaar", fAadhaarTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@fProfession", fProfessionTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@mName", mNameTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@mAadhaar", mAadhaarTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@mProfession", mProfessionTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@phoneNo", mobileTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@email", emailTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@socialCategory", socialCategoryComboBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@religion", religionComboBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@ews", ewsCheckBoxA.Checked);
                            sqlCommand.Parameters.AddWithValue("@dg", dgCheckBoxA.Checked);
                            sqlCommand.Parameters.AddWithValue("@address", addressTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@class", classTextBoxA.Text);
                            sqlCommand.Parameters.AddWithValue("@section", sectionTextBoxA.Text);

                            int saved = sqlCommand.ExecuteNonQuery();
                            if (saved == 2)
                            {
                                MessageBox.Show("Records saved - " + saved + " row affected!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Records not saved! Contact System Admisitrator.", "Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                            MessageBox.Show("The following admission number already exists. \nSolution: Enter different Admission Number!", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(ex.Message);
                    }
                    sqlConnection.Close();
                }
                clearButtonA.PerformClick();
            }
            else
            {
                // If validation conditions aren't met then show error box!

            }

        }

        /// <summary>
        /// MODIFY BUTTON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyButton_Click(object sender, EventArgs e)
        {
            DialogResult verify = MessageBox.Show("Are you sure you want to modify data?", "Modify Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (verify == DialogResult.Yes)
            {
                if (searchTextBoxM.Text != admissionNoTextBoxM.Text)
                {
                    DialogResult verifyAdmNoChange = MessageBox.Show("You are changing the admission number as well. Continue?", "Modify Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (verifyAdmNoChange == DialogResult.Yes)
                    {
                        // Creating Button Object of Control Type
                        KryptonButton ctrl = (KryptonButton)sender;

                        // Sending Button Object Parent and Checking for Validations 
                        if (/*validationsCheck(ctrl.Parent) ==*/ true)
                        {
                            int currentSession = getCurrentSessionYear();
                            // If validation conditions are met then save in database 
                            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                            {
                                sqlConnection.Open();
                                try
                                {
                                    string commandStr = @"UPDATE Student SET AdmissionNo = @admNo, Name = @sName, Aadhaar = @aadhaar, Gender = @gender, DOB = @dob, DOA = @doa, FName = @fName,
                                                          FAadhaar = @fAadhaar, FProfession = @fProfession, MName = @mName, MAadhaar = @mAadhaar, MProfession = @mProfession, PhoneNumber = @phoneNo, 
                                                          Email = @email, SocialCategory = @socialCategory, Religion = @religion, EWS = @ews, DG = @dg, Address = @address) where AdmissionNo = @admNoMain;
                                              UPDATE Class" + currentSession + " SET AdmNo = @admNo , Class = @class, Sec = @section) WHERE AdmNo = @admNoMain;";
                                    MessageBox.Show(commandStr);
                                    using (SqlCommand sqlCommand = new SqlCommand(commandStr, sqlConnection))
                                    {
                                        sqlCommand.Parameters.AddWithValue("@admNoMain", int.Parse(searchTextBoxM.Text));
                                        sqlCommand.Parameters.AddWithValue("@admNo", int.Parse(admissionNoTextBoxM.Text));
                                        sqlCommand.Parameters.AddWithValue("@sName", studentNameTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@aadhaar", aadhaarTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@gender", genderComboBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@dob", dobDateTimePickerM.Value.Date);
                                        sqlCommand.Parameters.AddWithValue("@doa", doaDateTimePickerM.Value.Date);
                                        sqlCommand.Parameters.AddWithValue("@fName", fNameTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@fAadhaar", fAadhaarTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@fProfession", fProfessionTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@mName", mNameTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@mAadhaar", mAadhaarTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@mProfession", mProfessionTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@phoneNo", mobileTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@email", emailTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@socialCategory", socialCategoryComboBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@religion", religionComboBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@ews", ewsCheckBoxM.Checked);
                                        sqlCommand.Parameters.AddWithValue("@dg", dgCheckBoxM.Checked);
                                        sqlCommand.Parameters.AddWithValue("@address", addressTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@class", classTextBoxM.Text);
                                        sqlCommand.Parameters.AddWithValue("@section", sectionTextBoxM.Text);

                                        int saved = sqlCommand.ExecuteNonQuery();
                                        if (saved == 2)
                                        {
                                            MessageBox.Show("Records updated - " + saved + " row affected!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Records not saved! Contact System Admisitrator.", "Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                catch (SqlException ex)
                                {
                                    if (ex.Number == 2627)
                                        MessageBox.Show("The following admission number already exists. \nSolution: Enter different Admission Number!", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                        MessageBox.Show(ex.Message);
                                }
                                sqlConnection.Close();
                            }
                        }
                        else
                        {
                            // If validation conditions aren't met then show error box!

                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult verify = MessageBox.Show("Are you sure you want to delete student data?", "Delete Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (verify == DialogResult.Yes)
            {
                int delete = 0;
                int currentSession = getCurrentSessionYear();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    try
                    {
                        string commandStr = @"DELETE FROM Student WHERE AdmissionNo = @admNo;
                                              DELETE FROM Class" + currentSession + " WHERE AdmNo = @admNo";
                        using (SqlCommand sqlCommand = new SqlCommand(commandStr, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@admNo", int.Parse(admissionNoTextBoxD.Text));
                            delete = sqlCommand.ExecuteNonQuery();
                            if (delete == 2)
                            {
                                MessageBox.Show("Records deleted - " + delete + " row affected!", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Records not deleted! Contact System Admisitrator.", "Data Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    sqlConnection.Close();
                }
            }
        }

        private void addMarksButton_Click(object sender, EventArgs e)
        {

        }
    }
}