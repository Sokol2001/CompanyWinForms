using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sokol
{
    public partial class EditDepartments : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommandBuilder sqlBuilder = null;
        private bool newRowAdding = false; 
        private String ConnectionString;

        public EditDepartments(String connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
        }

        private void EditDepartments_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                dataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [ACTIONS] FROM DEPARTMENT", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(dataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "DEPARTMENT");

                DeptDb.DataSource = dataSet.Tables["DEPARTMENT"];
                DeptDb.AutoResizeColumns();

                for (int i = 0; i < DeptDb.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    DeptDb[2, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshDeptDb_Click(object sender, EventArgs e)
        {
            dataSet.Tables["DEPARTMENT"].Clear();

            dataAdapter.Fill(dataSet, "DEPARTMENT");

            DeptDb.DataSource = dataSet.Tables["DEPARTMENT"];
            DeptDb.AutoResizeColumns();

            for (int i = 0; i < DeptDb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                DeptDb[2, i] = linkCell;
            }

        }


        private void DeptDb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    string task = DeptDb.Rows[e.RowIndex].Cells[2].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Delete this department?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            DeptDb.Rows.RemoveAt(e.RowIndex);

                            dataSet.Tables["DEPARTMENT"].Rows[e.RowIndex].Delete();

                            dataAdapter.Update(dataSet, "DEPARTMENT");
                        }
                    }
                    else if (task == "Insert")
                    {
                        DataRow row = dataSet.Tables["DEPARTMENT"].NewRow();

                        row[0] = DeptDb.Rows[e.RowIndex].Cells[0].Value;
                        row[1] = DeptDb.Rows[e.RowIndex].Cells[1].Value;

                        dataSet.Tables["DEPARTMENT"].Rows.Add(row);

                        dataSet.Tables["DEPARTMENT"].Rows.RemoveAt(dataSet.Tables["DEPARTMENT"].Rows.Count - 1);

                        DeptDb.Rows.RemoveAt(DeptDb.Rows.Count - 2);

                        DeptDb.Rows[e.RowIndex].Cells[2].Value = "Delete";

                        dataAdapter.Update(dataSet, "DEPARTMENT");

                        newRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        dataSet.Tables["DEPARTMENT"].Rows[e.RowIndex]["DEPARTMENT_ID"] = DeptDb.Rows[e.RowIndex].Cells["DEPARTMENT_ID"].Value;
                        dataSet.Tables["DEPARTMENT"].Rows[e.RowIndex]["DEPARTMENT_NAME"] = DeptDb.Rows[e.RowIndex].Cells["DEPARTMENT_NAME"].Value;

                        DeptDb.Rows[e.RowIndex].Cells[2].Value = "Delete";

                        dataAdapter.Update(dataSet, "DEPARTMENT");

                        RefreshDeptDb_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an employee of this department");
            }
        }

        private void DeptDb_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = DeptDb.Rows.Count - 2;

                    DataGridViewRow row = DeptDb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    DeptDb[2, lastRow] = linkCell;

                    row.Cells["ACTIONS"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeptDb_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = DeptDb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = DeptDb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    DeptDb[2, rowIndex] = linkCell;

                    editingRow.Cells["ACTIONS"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditDepartments_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void DeptDb_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(FilterKeyPress);

            if (DeptDb.CurrentCell.ColumnIndex == 0)
            {
                TextBox textBox = e.Control as TextBox;

                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(FilterKeyPress);
                }
            }
        }

        private void FilterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
