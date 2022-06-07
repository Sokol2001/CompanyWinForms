namespace Sokol
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EmployeeDb = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateDb = new System.Windows.Forms.LinkLabel();
            this.Report = new System.Windows.Forms.LinkLabel();
            this.Payment = new System.Windows.Forms.LinkLabel();
            this.AddEmployee = new System.Windows.Forms.LinkLabel();
            this.EditPositions = new System.Windows.Forms.LinkLabel();
            this.EditDepartments = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDb)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.EmployeeDb);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 450);
            this.panel1.TabIndex = 0;
            // 
            // EmployeeDb
            // 
            this.EmployeeDb.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Baskerville Old Face", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeDb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeeDb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EmployeeDb.DefaultCellStyle = dataGridViewCellStyle2;
            this.EmployeeDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeeDb.Location = new System.Drawing.Point(0, 58);
            this.EmployeeDb.Name = "EmployeeDb";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeDb.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.EmployeeDb.RowHeadersWidth = 51;
            this.EmployeeDb.RowTemplate.Height = 20;
            this.EmployeeDb.Size = new System.Drawing.Size(1044, 392);
            this.EmployeeDb.TabIndex = 1;
            this.EmployeeDb.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmployeeDb_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.FilterComboBox);
            this.panel2.Controls.Add(this.UpdateDb);
            this.panel2.Controls.Add(this.Report);
            this.panel2.Controls.Add(this.Payment);
            this.panel2.Controls.Add(this.AddEmployee);
            this.panel2.Controls.Add(this.EditPositions);
            this.panel2.Controls.Add(this.EditDepartments);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 58);
            this.panel2.TabIndex = 0;
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.FilterComboBox.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilterComboBox.ForeColor = System.Drawing.Color.Green;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Location = new System.Drawing.Point(150, 10);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(189, 34);
            this.FilterComboBox.TabIndex = 2;
            this.FilterComboBox.Text = "Filtering the base";
            // 
            // UpdateDb
            // 
            this.UpdateDb.AutoSize = true;
            this.UpdateDb.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UpdateDb.LinkColor = System.Drawing.Color.Green;
            this.UpdateDb.Location = new System.Drawing.Point(12, 14);
            this.UpdateDb.Name = "UpdateDb";
            this.UpdateDb.Size = new System.Drawing.Size(125, 26);
            this.UpdateDb.TabIndex = 0;
            this.UpdateDb.TabStop = true;
            this.UpdateDb.Text = "Update base";
            this.UpdateDb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UpdateDb_LinkClicked);
            // 
            // Report
            // 
            this.Report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Report.AutoSize = true;
            this.Report.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Report.LinkColor = System.Drawing.Color.Black;
            this.Report.Location = new System.Drawing.Point(935, 14);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(75, 26);
            this.Report.TabIndex = 4;
            this.Report.TabStop = true;
            this.Report.Text = "Report";
            this.Report.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Report.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Report_LinkClicked);
            // 
            // Payment
            // 
            this.Payment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Payment.AutoSize = true;
            this.Payment.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Payment.LinkColor = System.Drawing.Color.Black;
            this.Payment.Location = new System.Drawing.Point(832, 14);
            this.Payment.Name = "Payment";
            this.Payment.Size = new System.Drawing.Size(99, 26);
            this.Payment.TabIndex = 3;
            this.Payment.TabStop = true;
            this.Payment.Text = "Payments";
            this.Payment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Payment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Payment_LinkClicked);
            // 
            // AddEmployee
            // 
            this.AddEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEmployee.AutoSize = true;
            this.AddEmployee.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddEmployee.LinkColor = System.Drawing.Color.Black;
            this.AddEmployee.Location = new System.Drawing.Point(670, 14);
            this.AddEmployee.Name = "AddEmployee";
            this.AddEmployee.Size = new System.Drawing.Size(154, 26);
            this.AddEmployee.TabIndex = 2;
            this.AddEmployee.TabStop = true;
            this.AddEmployee.Text = "Add employees";
            this.AddEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddEmployee.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddEmployee_LinkClicked);
            // 
            // EditPositions
            // 
            this.EditPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditPositions.AutoSize = true;
            this.EditPositions.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditPositions.LinkColor = System.Drawing.Color.Black;
            this.EditPositions.Location = new System.Drawing.Point(514, 14);
            this.EditPositions.Name = "EditPositions";
            this.EditPositions.Size = new System.Drawing.Size(138, 26);
            this.EditPositions.TabIndex = 1;
            this.EditPositions.TabStop = true;
            this.EditPositions.Text = "Edit positions";
            this.EditPositions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EditPositions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EditPositions_LinkClicked);
            // 
            // EditDepartments
            // 
            this.EditDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditDepartments.AutoSize = true;
            this.EditDepartments.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditDepartments.LinkColor = System.Drawing.Color.Black;
            this.EditDepartments.Location = new System.Drawing.Point(342, 14);
            this.EditDepartments.Name = "EditDepartments";
            this.EditDepartments.Size = new System.Drawing.Size(168, 26);
            this.EditDepartments.TabIndex = 0;
            this.EditDepartments.TabStop = true;
            this.EditDepartments.Text = "Edit departments";
            this.EditDepartments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EditDepartments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EditDepartments_LinkClicked);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 450);
            this.Controls.Add(this.panel1);
            this.Name = "MenuForm";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForm_FormClosed);
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDb)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView EmployeeDb;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.LinkLabel UpdateDb;
        private System.Windows.Forms.LinkLabel Report;
        private System.Windows.Forms.LinkLabel Payment;
        private System.Windows.Forms.LinkLabel AddEmployee;
        private System.Windows.Forms.LinkLabel EditPositions;
        private System.Windows.Forms.LinkLabel EditDepartments;
    }
}

