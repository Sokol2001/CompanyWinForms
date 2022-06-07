using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sokol
{
    public partial class Payments : Form
    {
        private SqlConnection sqlConnection = null;
        private String ConnectionString;

        public Payments(String connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            DeptSalary.ReadOnly = true;
            DeptMoney.ReadOnly = true;
            DeptBonus.ReadOnly = true;

            sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            SqlDataReader dataReader = null;

            var sesected = FilterComboBox.SelectedIndex;

            FilterComboBox.Items.Clear();

            FilterComboBox.Items.Add("All");

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
   
        private void CoutnMoney()
        {
            int salary = 0, bonus = 0;

            SqlDataReader dataReader = null;

            try
            {
                if (FilterComboBox.SelectedIndex == 0)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT EMPLOYEE.SALARY, EMPLOYEE.KPI " +
                            "FROM EMPLOYEE, DEPARTMENT " +
                            "WHERE DEPARTMENT.DEPARTMENT_ID = EMPLOYEE.DEPT_ID", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {

                        salary += Convert.ToInt32(dataReader["SALARY"]);
                        bonus += Convert.ToInt32(
                                Convert.ToString(dataReader["KPI"]) == "A" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.2, 4) :
                                Convert.ToString(dataReader["KPI"]) == "B" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.3, 4) :
                                Convert.ToString(dataReader["KPI"]) == "C" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.4, 4) :
                                0);
                    }

                    dataReader.Close();
                }
                else
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT DEPARTMENT.DEPARTMENT_NAME, EMPLOYEE.SALARY, EMPLOYEE.KPI " +
                            "FROM EMPLOYEE, DEPARTMENT " +
                            "WHERE DEPARTMENT.DEPARTMENT_ID = EMPLOYEE.DEPT_ID", sqlConnection);

                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        if (Convert.ToString(dataReader["DEPARTMENT_NAME"]) == FilterComboBox.SelectedItem.ToString())
                        {
                            salary += Convert.ToInt32(dataReader["SALARY"]);
                            bonus += Convert.ToInt32(
                                    Convert.ToString(dataReader["KPI"]) == "A" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.2, 4) :
                                    Convert.ToString(dataReader["KPI"]) == "B" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.3, 4) :
                                    Convert.ToString(dataReader["KPI"]) == "C" ? Math.Round(Convert.ToInt32(dataReader["SALARY"]) * 0.4, 4) :
                                    0);
                        }
                    }

                    dataReader.Close();
                }
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

            DeptSalary.Text = Convert.ToString(salary);
            DeptBonus.Text = Convert.ToString(bonus);
            DeptMoney.Text = Convert.ToString(bonus + salary);
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CoutnMoney();
        }
    }
}
