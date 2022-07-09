using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SDSP
{
    public class MarksData
    {
        string studentName, fName, mName, dob, section;
        int className, attendance, totalDays;

        int sessionName, admNo;

        const string connectionString = @"Data Source = . ; Initial Catalog = SDPS ; Integrated Security = Yes ;";

        public MarksData (int session, int admNos=0)
        {
            sessionName = session;
            admNo = admNos;
        }

        public void FA1()
        {
            string exam = "FA1";
            int[] fa1Maths = { }, fa1English = { }, fa1Hindi= { }, fa1Sst = { }, fa1Science = { };
            int i = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string commandString = "SELECT English" + exam + " Hindi" + exam + " Maths" + exam + " Sst" + exam + " Science" + exam + " FROM FA" + sessionName + " WHERE AdmissionNO = @admNo";
                using (SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@admNo", admNo);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        fa1English[i] = int.Parse(dataReader[0].ToString());
                        fa1Hindi[i] = int.Parse(dataReader[1].ToString());
                        fa1Maths[i] = int.Parse(dataReader[2].ToString());
                        fa1Sst[i] = int.Parse(dataReader[3].ToString());
                        fa1Science[i] = int.Parse(dataReader[4].ToString());
                        i++;
                    }
                    sqlConnection.Close();
                }


            }

        }

        public void FA2()
        {

        }

        public void FA3()
        {

        }

        public void FA4()
        {

        }

        public void SA1()
        {

        }

        public void SA2()
        {

        }

        public void Annual()
        {

        }
    }
}
