using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sokol
{
    public partial class EditEmployee : Form
    {
        private int RowIndex;
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataReader dataReader = null;
        private String ConnectionString;

        public EditEmployee(int index, String connectionString)
        {
            InitializeComponent();
            RowIndex = index;
            ConnectionString = connectionString;
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT DEPARTMENT_NAME FROM DEPARTMENT", sqlConnection);

                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    EmployeeDeptComboBox.Items.Add(Convert.ToString(dataReader["DEPARTMENT_NAME"]));
                }

                dataReader.Close();

                sqlCommand = new SqlCommand("SELECT POSITION_NAME FROM POSITION", sqlConnection);

                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    EmployeePositionComboBox.Items.Add(Convert.ToString(dataReader["POSITION_NAME"]));
                }

                dataReader.Close();

                dataAdapter = new SqlDataAdapter("SELECT * FROM EMPLOYEE", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(dataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "EMPLOYEE");

                EmployeeCode.ReadOnly = true;

                EmployeeCode.Text = dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["UNIQUE_CODE"].ToString();
                EmployeeFirstName.Text = dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["FIRST_NAME"].ToString();
                EmployeeLastName.Text = dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["LAST_NAME"].ToString();
                EmployeeMiddleName.Text = dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["MIDDLE_NAME"].ToString();
                EmployeePhone.Text = dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["PHONE"].ToString();
                EmployeeAddress.Text = dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["ADDRESS"].ToString();

                sqlCommand = new SqlCommand("SELECT DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID = '" +
                    dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["DEPT_ID"].ToString() + "'", sqlConnection);
                
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();

                EmployeeDeptComboBox.Text = Convert.ToString(dataReader["DEPARTMENT_NAME"]);

                dataReader.Close();

                sqlCommand = new SqlCommand("SELECT POSITION_NAME FROM POSITION WHERE POSITION_ID = '" +
                    dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["POSITION_ID"].ToString() + "'", sqlConnection);

                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();

                EmployeePositionComboBox.Text = Convert.ToString(dataReader["POSITION_NAME"]);

                dataReader.Close();

                EmployeeSalary.Text = dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["SALARY"].ToString();
                EmployeeKPIComboBox.Text = dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["KPI"].ToString();
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this employee?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
            {
                dataSet.Tables["EMPLOYEE"].Rows[RowIndex].Delete();

                dataAdapter.Update(dataSet, "EMPLOYEE");
            }

            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["FIRST_NAME"] = EmployeeFirstName.Text;
                dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["LAST_NAME"] = EmployeeLastName.Text;
                dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["MIDDLE_NAME"] = EmployeeMiddleName.Text;
                dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["PHONE"] = EmployeeLastName.Text;
                dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["ADDRESS"] = EmployeeLastName.Text;

                SqlCommand SqlCommand = new SqlCommand("SELECT DEPARTMENT_ID FROM DEPARTMENT " +
                        "WHERE DEPARTMENT_NAME = '" + EmployeeDeptComboBox.SelectedItem + "'", sqlConnection);

                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();

                dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["DEPT_ID"] = Convert.ToInt32(dataReader["DEPARTMENT_ID"]);

                dataReader.Close();

                SqlCommand = new SqlCommand("SELECT POSITION_ID FROM POSITION " +
                        "WHERE POSITION_NAME = '" + EmployeePositionComboBox.SelectedItem + "'", sqlConnection);

                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();

                dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["POSITION_ID"] = Convert.ToInt32(dataReader["POSITION_ID"]);

                dataReader.Close();

                dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["SALARY"] = EmployeeSalary.Text;

                switch (EmployeeKPIComboBox.SelectedIndex)
                {
                    case 0:
                        dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["KPI"] = "A";
                        break;
                    case 1:
                        dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["KPI"] = "B";
                        break;
                    case 2:
                        dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["KPI"] = "C";
                        break;
                    default:
                        dataSet.Tables["EMPLOYEE"].Rows[RowIndex]["KPI"] = "";
                        break;
                }

                dataAdapter.Update(dataSet, "EMPLOYEE");

                MessageBox.Show("Employee has been updated");

                this.Hide();
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

        private void EmployeeSalary_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
