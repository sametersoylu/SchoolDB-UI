namespace WinFormsApp1
{
    partial class Form3
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
            this.uc1 = new WinFormsApp1.UserControl1();
            this.SuspendLayout();
            // 
            // uc1
            // 
            this.uc1.BackColor = System.Drawing.Color.White;
            this.uc1.DepartmentBoxDataSource = null;
            this.uc1.DepartmentBoxDisplayMember = "";
            this.uc1.DepartmentTextBox = "";
            this.uc1.IDBoxDataSource = null;
            this.uc1.IDBoxDisplayMember = "";
            this.uc1.IDTextBox = "";
            this.uc1.Location = new System.Drawing.Point(9, 7);
            this.uc1.Name = "uc1";
            this.uc1.NameBoxDataSource = null;
            this.uc1.NameBoxDisplayMember = "";
            this.uc1.NameTextBox = "";
            this.uc1.Size = new System.Drawing.Size(500, 284);
            this.uc1.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(511, 293);
            this.Controls.Add(this.uc1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Student";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl1 uc1;
    }
}