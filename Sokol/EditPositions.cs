using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sokol
{
    public partial class EditPositions : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommandBuilder sqlBuilder = null;
        private bool newRowAdding = false;
        private String ConnectionString;

        public EditPositions(String connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
        }

        private void EditPositions_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                dataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [ACTIONS] FROM POSITION", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(dataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "POSITION");

                PositionDb.DataSource = dataSet.Tables["POSITION"];
                PositionDb.AutoResizeColumns();

                for (int i = 0; i < PositionDb.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    PositionDb[2, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshPositionDb_Click(object sender, EventArgs e)
        {
            dataSet.Tables["POSITION"].Clear();

            dataAdapter.Fill(dataSet, "POSITION");

            PositionDb.DataSource = dataSet.Tables["POSITION"];
            PositionDb.AutoResizeColumns();

            for (int i = 0; i < PositionDb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                PositionDb[2, i] = linkCell;
            }
        }

        private void PositionDb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    string task = PositionDb.Rows[e.RowIndex].Cells[2].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Delete this POSITION?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            PositionDb.Rows.RemoveAt(rowIndex);

                            dataSet.Tables["POSITION"].Rows[rowIndex].Delete();

                            dataAdapter.Update(dataSet, "POSITION");
                        }
                    }
                    else if (task == "Insert")
                    {

                        DataRow row = dataSet.Tables["POSITION"].NewRow();

                        row[0] = PositionDb.Rows[e.RowIndex].Cells[0].Value;
                        row[1] = PositionDb.Rows[e.RowIndex].Cells[1].Value;

                        dataSet.Tables["POSITION"].Rows.Add(row);

                        dataSet.Tables["POSITION"].Rows.RemoveAt(dataSet.Tables["POSITION"].Rows.Count - 1);

                        PositionDb.Rows.RemoveAt(PositionDb.Rows.Count - 2);

                        PositionDb.Rows[e.RowIndex].Cells[2].Value = "Delete";

                        dataAdapter.Update(dataSet, "POSITION");

                        newRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        int rowIndex = e.RowIndex;

                        dataSet.Tables["POSITION"].Rows[rowIndex]["POSITION_ID"] = PositionDb.Rows[rowIndex].Cells["POSITION_ID"].Value;
                        dataSet.Tables["POSITION"].Rows[rowIndex]["POSITION_NAME"] = PositionDb.Rows[rowIndex].Cells["POSITION_NAME"].Value;

                        PositionDb.Rows[e.RowIndex].Cells[2].Value = "Delete";

                        dataAdapter.Update(dataSet, "POSITION");
                        RefreshPositionDb_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an employee of this position");
            }
        }

        private void PositionDb_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = PositionDb.Rows.Count - 2;

                    DataGridViewRow row = PositionDb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    PositionDb[2, lastRow] = linkCell;

                    row.Cells["ACTIONS"].Value = "Insert";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PositionDb_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = PositionDb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = PositionDb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    PositionDb[2, rowIndex] = linkCell;

                    editingRow.Cells["ACTIONS"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditPositions_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void PositionDb_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(FilterKeyPress);

            if (PositionDb.CurrentCell.ColumnIndex == 0)
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
