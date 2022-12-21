namespace WinFormsApp1
{
    partial class Form2
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
            this.nTextBox1 = new WinFormsApp1.NTextBox();
            this.nTextBox2 = new WinFormsApp1.NTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nTextBox1
            // 
            this.nTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.nTextBox1.BorderColor = System.Drawing.Color.Crimson;
            this.nTextBox1.BorderWidth = 2;
            this.nTextBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.nTextBox1.Location = new System.Drawing.Point(12, 24);
            this.nTextBox1.Name = "nTextBox1";
            this.nTextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.nTextBox1.Size = new System.Drawing.Size(251, 30);
            this.nTextBox1.SystemPasswordChar = false;
            this.nTextBox1.TabIndex = 0;
            this.nTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.nTextBox1.TextBoxText = "";
            this.nTextBox1.UnderlinedStyle = true;
            // 
            // nTextBox2
            // 
            this.nTextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.nTextBox2.BorderColor = System.Drawing.Color.Crimson;
            this.nTextBox2.BorderWidth = 2;
            this.nTextBox2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.nTextBox2.Location = new System.Drawing.Point(12, 72);
            this.nTextBox2.Name = "nTextBox2";
            this.nTextBox2.Padding = new System.Windows.Forms.Padding(7);
            this.nTextBox2.Size = new System.Drawing.Size(251, 30);
            this.nTextBox2.SystemPasswordChar = true;
            this.nTextBox2.TabIndex = 1;
            this.nTextBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.nTextBox2.TextBoxText = "";
            this.nTextBox2.UnderlinedStyle = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(63, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Bağlan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(139, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "Çıkış";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kullanıcı Adı";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(69, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 23);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Schema: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(275, 202);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nTextBox2);
            this.Controls.Add(this.nTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private NTextBox nTextBox1;
        private NTextBox nTextBox2;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
    }
}