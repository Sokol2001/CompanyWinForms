using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokol
{
    public partial class Start : Form
    {
        private String ConnectionString;

        public Start()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            if (openFileDialog1.FileName.EndsWith(".mdf"))
            {

                string filename = openFileDialog1.FileName;

                MessageBox.Show("File opened successfully");
                ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                    filename.ToString() + ";Integrated Security=True";

                MenuForm menuForm = new MenuForm(ConnectionString);

                menuForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("File must be .mdf! Please try again.");
            }

        }
    }
}
