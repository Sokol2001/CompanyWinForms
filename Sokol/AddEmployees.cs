using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sokol
{
    public partial class AddEmployee : Form
    {
        private SqlConnection sqlConnection = null;
        private String ConnectionString;

        public AddEmployee(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            SqlDataReader dataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT DEPARTMENT_NAME FROM DEPARTMENT", sqlConnection);

                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    EmployeeDeptComboBox.Items.Add(Convert.ToString(dataReader["DEPARTMENT_NAME"]));
                }

                EmployeeDeptComboBox.Text = EmployeeDeptComboBox.Items[0].ToString();

                dataReader.Close();

                sqlCommand = new SqlCommand("SELECT POSITION_NAME FROM POSITION", sqlConnection);

                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    EmployeePositionComboBox.Items.Add(Convert.ToString(dataReader["POSITION_NAME"]));
                }

                EmployeePositionComboBox.Text = EmployeePositionComboBox.Items[0].ToString();

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dataReader = null;

                SqlCommand command = new SqlCommand(
                    "INSERT INTO EMPLOYEE (UNIQUE_CODE, FIRST_NAME, LAST_NAME, MIDDLE_NAME, " +
                    "PHONE, ADDRESS, DEPT_ID, POSITION_ID, SALARY, KPI) VALUES (@UNIQUE_CODE, " +
                    "@FIRST_NAME, @LAST_NAME, @MIDDLE_NAME, @PHONE, @ADDRESS, @DEPT_ID, " +
                    "@POSITION_ID, @SALARY, @KPI)", sqlConnection);

                command.Parameters.AddWithValue("UNIQUE_CODE", EmployeeCode.Text);
                command.Parameters.AddWithValue("FIRST_NAME", EmployeeFirstName.Text);
                command.Parameters.AddWithValue("LAST_NAME", EmployeeLastName.Text);
                command.Parameters.AddWithValue("MIDDLE_NAME", EmployeeMiddleName.Text);
                command.Parameters.AddWithValue("PHONE", EmployeePhone.Text);
                command.Parameters.AddWithValue("ADDRESS", EmployeeAddress.Text);

                SqlCommand SqlCommand = new SqlCommand("SELECT DEPARTMENT_ID FROM DEPARTMENT " +
                    "WHERE DEPARTMENT_NAME = '" + EmployeeDeptComboBox.SelectedItem + "'", sqlConnection);

                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();

                command.Parameters.AddWithValue("DEPT_ID", dataReader["DEPARTMENT_ID"]);

                dataReader.Close();

                dataReader = null;

                SqlCommand = new SqlCommand("SELECT POSITION_ID FROM POSITION " +
                    "WHERE POSITION_NAME = '" + EmployeePositionComboBox.SelectedItem + "'", sqlConnection);

                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();

                command.Parameters.AddWithValue("POSITION_ID", dataReader["POSITION_ID"]);

                dataReader.Close();

                command.Parameters.AddWithValue("SALARY", EmployeeSalary.Text);

                switch (EmployeeKPIComboBox.SelectedIndex)
                {
                    case 0:
                        command.Parameters.AddWithValue("KPI", "A");
                        break;
                    case 1:
                        command.Parameters.AddWithValue("KPI", "B");
                        break;
                    case 2:
                        command.Parameters.AddWithValue("KPI", "C");
                        break;
                    default:
                        command.Parameters.AddWithValue("KPI", "");
                        break;
                }

                command.ExecuteReader();

                MessageBox.Show("Employye was add");

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void FilterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EmployeeCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EmployeePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EmployeeSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
