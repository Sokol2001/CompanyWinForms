using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Sokol
{
    public partial class MenuForm : Form
    {
        private SqlConnection sqlConnection = null;

        private String ConnectionString = "";

        public MenuForm(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {            
            sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            EmployeeDb.ReadOnly = true;

            FillComboBox();
        }

        private void UpdateDb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataReader dataReader = null;
            string[] employeeRow = null;

            FillComboBox();

            try
            {
                if (FilterComboBox.SelectedIndex == 0 || FilterComboBox.SelectedItem == null)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT EMPLOYEE.FIRST_NAME, EMPLOYEE.LAST_NAME, EMPLOYEE.MIDDLE_NAME, " +
                        "DEPARTMENT.DEPARTMENT_NAME, POSITION.POSITION_NAME, EMPLOYEE.SALARY, EMPLOYEE.KPI " +
                        "FROM EMPLOYEE, DEPARTMENT, POSITION " +
                        "WHERE DEPARTMENT.DEPARTMENT_ID = EMPLOYEE.DEPT_ID AND POSITION.POSITION_ID = EMPLOYEE.POSITION_ID", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();
                }
                else
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT EMPLOYEE.FIRST_NAME, EMPLOYEE.LAST_NAME, EMPLOYEE.MIDDLE_NAME, " +
                        "DEPARTMENT.DEPARTMENT_NAME, POSITION.POSITION_NAME, EMPLOYEE.SALARY, EMPLOYEE.KPI " +
                        "FROM EMPLOYEE, DEPARTMENT, POSITION " +
                        "WHERE DEPARTMENT.DEPARTMENT_ID = EMPLOYEE.DEPT_ID AND POSITION.POSITION_ID = EMPLOYEE.POSITION_ID " +
                        "AND DEPARTMENT.DEPARTMENT_NAME = '" + FilterComboBox.SelectedItem + "'", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();
                }

                dataTable.Columns.Add("First name");
                dataTable.Columns.Add("Last name");
                dataTable.Columns.Add("Middle name");
                dataTable.Columns.Add("Department");
                dataTable.Columns.Add("Position");
                dataTable.Columns.Add("Salary");
                dataTable.Columns.Add("KPI");
                dataTable.Columns.Add("Bonus");

                while (dataReader.Read())
                {
                    employeeRow = new string[]
                    {
                        Convert.ToString(dataReader["FIRST_NAME"]),
                        Convert.ToString(dataReader["LAST_NAME"]),
                        Convert.ToString(dataReader["MIDDLE_NAME"]),
                        Convert.ToString(dataReader["DEPARTMENT_NAME"]),
                        Convert.ToString(dataReader["POSITION_NAME"]),
                        Convert.ToString(dataReader["SALARY"]),
                        Convert.ToString(dataReader["KPI"]),
                        Convert.ToString(
                            Convert.ToString(dataReader["KPI"]) == "A" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.2, 4) :
                            Convert.ToString(dataReader["KPI"]) == "B" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.3, 4) :
                            Convert.ToString(dataReader["KPI"]) == "C" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.4, 4) :
                            ""),
                    };

                    dataTable.Rows.Add(employeeRow);
                }

                EmployeeDb.DataSource = dataTable;
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

        private void EditDepartments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form editDepartments = new EditDepartments(ConnectionString);

            editDepartments.Show();
        }

        private void EditPositions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form editPosition = new EditPositions(ConnectionString);

            editPosition.Show();
        }

        private void AddEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form addEmployee = new AddEmployee(ConnectionString);

            addEmployee.Show();
        }

        private void Payment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Payments payments = new Payments(ConnectionString);

            payments.Show();
        }

        private void Report_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateReport report = new CreateReport(ConnectionString);

            report.Show();
        }

        private void EmployeeDb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditEmployee editEmployee = new EditEmployee(e.RowIndex, ConnectionString);

                editEmployee.Show();
            }
        }

        private void FillComboBox()
        {
            SqlDataReader dataReader = null;

            var sesected = FilterComboBox.SelectedIndex;

            FilterComboBox.Items.Clear();

            FilterComboBox.Items.Add("Without filter");

            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT DEPARTMENT_NAME FROM DEPARTMENT", sqlConnection);

                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    FilterComboBox.Items.Add(Convert.ToString(dataReader["DEPARTMENT_NAME"]));
                }

                FilterComboBox.SelectedIndex = sesected;
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

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
