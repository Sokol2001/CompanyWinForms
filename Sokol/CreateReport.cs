using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Sokol
{
    public partial class CreateReport : Form
    {
        private SaveFileDialog saveFile = new SaveFileDialog();
        private SqlConnection sqlConnection = null;
        private String reportString = "";
        private String ConnectionString;

        public CreateReport(String connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
        }

        private void CreateReport_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            saveFile = new SaveFileDialog();

            SaveButton.Enabled = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            SqlDataReader dataReader = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT EMPLOYEE.FIRST_NAME, EMPLOYEE.LAST_NAME, EMPLOYEE.MIDDLE_NAME, " +
                        "DEPARTMENT.DEPARTMENT_NAME, POSITION.POSITION_NAME, EMPLOYEE.SALARY, EMPLOYEE.KPI " +
                        "FROM EMPLOYEE, DEPARTMENT, POSITION " +
                        "WHERE DEPARTMENT.DEPARTMENT_ID = EMPLOYEE.DEPT_ID AND POSITION.POSITION_ID = EMPLOYEE.POSITION_ID " +
                        "ORDER BY DEPARTMENT.DEPARTMENT_NAME", sqlConnection);

                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    reportString += "Name: ";
                    reportString += Convert.ToString(dataReader["FIRST_NAME"]) + " ";
                    reportString += Convert.ToString(dataReader["LAST_NAME"]) + " ";
                    reportString += Convert.ToString(dataReader["MIDDLE_NAME"]) + "\n";
                    reportString += "Department: ";
                    reportString += Convert.ToString(dataReader["DEPARTMENT_NAME"]) + "\n";
                    reportString += "Position: ";
                    reportString += Convert.ToString(dataReader["POSITION_NAME"]) + "\n";
                    reportString += "Salary: ";
                    reportString += Convert.ToString(dataReader["SALARY"]) + "| ";
                    reportString += "KPI: ";
                    reportString += Convert.ToString(dataReader["KPI"]) + "| ";
                    reportString += "Bonuse: ";
                    reportString += Convert.ToString(
                        Convert.ToString(dataReader["KPI"]) == "A" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.2, 4) :
                        Convert.ToString(dataReader["KPI"]) == "B" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.3, 4) :
                        Convert.ToString(dataReader["KPI"]) == "C" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.4, 4) :
                        "") + "\n===============\n";                    
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }

            }

            SaveButton.Enabled = true;
            CreateButton.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFile.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFile.FileName;

            File.WriteAllText(filename, reportString);

            CreateButton.Enabled = false;
            SaveButton.Enabled = false;
        }
    }
}
