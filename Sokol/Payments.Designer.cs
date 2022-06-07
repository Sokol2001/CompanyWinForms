
namespace Sokol
{
    partial class Payments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DeptSalary = new System.Windows.Forms.TextBox();
            this.DeptBonus = new System.Windows.Forms.TextBox();
            this.Bonus = new System.Windows.Forms.Label();
            this.DeptMoney = new System.Windows.Forms.TextBox();
            this.Tota = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.BackColor = System.Drawing.Color.White;
            this.FilterComboBox.Font = new System.Drawing.Font("Baskerville Old Face", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilterComboBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Location = new System.Drawing.Point(62, 136);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(192, 39);
            this.FilterComboBox.TabIndex = 3;
            this.FilterComboBox.Text = "Make a choice";
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(785, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "The amount of money set aside for the salaries of all employees";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(62, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(302, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Salary";
            // 
            // DeptSalary
            // 
            this.DeptSalary.Font = new System.Drawing.Font("Baskerville Old Face", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeptSalary.Location = new System.Drawing.Point(304, 136);
            this.DeptSalary.Name = "DeptSalary";
            this.DeptSalary.Size = new System.Drawing.Size(192, 38);
            this.DeptSalary.TabIndex = 8;
            // 
            // DeptBonus
            // 
            this.DeptBonus.Font = new System.Drawing.Font("Baskerville Old Face", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeptBonus.Location = new System.Drawing.Point(546, 136);
            this.DeptBonus.Name = "DeptBonus";
            this.DeptBonus.Size = new System.Drawing.Size(192, 38);
            this.DeptBonus.TabIndex = 10;
            // 
            // Bonus
            // 
            this.Bonus.AutoSize = true;
            this.Bonus.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Bonus.ForeColor = System.Drawing.Color.Black;
            this.Bonus.Location = new System.Drawing.Point(547, 104);
            this.Bonus.Name = "Bonus";
            this.Bonus.Size = new System.Drawing.Size(76, 26);
            this.Bonus.TabIndex = 9;
            this.Bonus.Text = "Bonus";
            // 
            // DeptMoney
            // 
            this.DeptMoney.Font = new System.Drawing.Font("Baskerville Old Face", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeptMoney.Location = new System.Drawing.Point(304, 237);
            this.DeptMoney.Name = "DeptMoney";
            this.DeptMoney.Size = new System.Drawing.Size(192, 38);
            this.DeptMoney.TabIndex = 12;
            // 
            // Tota
            // 
            this.Tota.AutoSize = true;
            this.Tota.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.Tota.ForeColor = System.Drawing.Color.Black;
            this.Tota.Location = new System.Drawing.Point(304, 208);
            this.Tota.Name = "Tota";
            this.Tota.Size = new System.Drawing.Size(67, 26);
            this.Tota.TabIndex = 11;
            this.Tota.Text = "Total";
            // 
            // Payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(172)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeptMoney);
            this.Controls.Add(this.Tota);
            this.Controls.Add(this.DeptBonus);
            this.Controls.Add(this.Bonus);
            this.Controls.Add(this.DeptSalary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilterComboBox);
            this.Name = "Payments";
            this.Text = "Payments";
            this.Load += new System.EventHandler(this.Payments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DeptSalary;
        private System.Windows.Forms.TextBox DeptBonus;
        private System.Windows.Forms.Label Bonus;
        private System.Windows.Forms.TextBox DeptMoney;
        private System.Windows.Forms.Label Tota;
    }
}