namespace WinFormsApp1
{
    partial class UserControl1
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataID = new WinFormsApp1.NTextBox();
            this.DataName = new WinFormsApp1.NTextBox();
            this.DataDepartment = new WinFormsApp1.NTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AdditionalData = new WinFormsApp1.NTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AdditionalData2 = new WinFormsApp1.NTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataID
            // 
            this.DataID.BackColor = System.Drawing.SystemColors.Window;
            this.DataID.BorderColor = System.Drawing.Color.DimGray;
            this.DataID.BorderWidth = 2;
            this.DataID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DataID.Location = new System.Drawing.Point(6, 22);
            this.DataID.Name = "DataID";
            this.DataID.Padding = new System.Windows.Forms.Padding(7);
            this.DataID.PlaceHolder = "ID";
            this.DataID.Size = new System.Drawing.Size(203, 30);
            this.DataID.SystemPasswordChar = false;
            this.DataID.TabIndex = 3;
            this.DataID.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.DataID.TextBoxText = "";
            this.DataID.UnderlinedStyle = true;
            // 
            // DataName
            // 
            this.DataName.BackColor = System.Drawing.SystemColors.Window;
            this.DataName.BorderColor = System.Drawing.Color.DimGray;
            this.DataName.BorderWidth = 2;
            this.DataName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DataName.Location = new System.Drawing.Point(6, 58);
            this.DataName.Name = "DataName";
            this.DataName.Padding = new System.Windows.Forms.Padding(7);
            this.DataName.PlaceHolder = "Name";
            this.DataName.Size = new System.Drawing.Size(203, 30);
            this.DataName.SystemPasswordChar = false;
            this.DataName.TabIndex = 4;
            this.DataName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.DataName.TextBoxText = "";
            this.DataName.UnderlinedStyle = true;
            // 
            // DataDepartment
            // 
            this.DataDepartment.BackColor = System.Drawing.SystemColors.Window;
            this.DataDepartment.BorderColor = System.Drawing.Color.DimGray;
            this.DataDepartment.BorderWidth = 2;
            this.DataDepartment.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DataDepartment.Location = new System.Drawing.Point(6, 94);
            this.DataDepartment.Name = "DataDepartment";
            this.DataDepartment.Padding = new System.Windows.Forms.Padding(7);
            this.DataDepartment.PlaceHolder = "Department";
            this.DataDepartment.Size = new System.Drawing.Size(203, 30);
            this.DataDepartment.SystemPasswordChar = false;
            this.DataDepartment.TabIndex = 5;
            this.DataDepartment.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.DataDepartment.TextBoxText = "";
            this.DataDepartment.UnderlinedStyle = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataID);
            this.groupBox1.Controls.Add(this.AdditionalData2);
            this.groupBox1.Controls.Add(this.AdditionalData);
            this.groupBox1.Controls.Add(this.DataDepartment);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.DataName);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(369, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 312);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SelectedData";
            // 
            // AdditionalData
            // 
            this.AdditionalData.BackColor = System.Drawing.SystemColors.Window;
            this.AdditionalData.BorderColor = System.Drawing.Color.DimGray;
            this.AdditionalData.BorderWidth = 2;
            this.AdditionalData.ForeColor = System.Drawing.SystemColors.GrayText;
            this.AdditionalData.Location = new System.Drawing.Point(6, 130);
            this.AdditionalData.Name = "AdditionalData";
            this.AdditionalData.Padding = new System.Windows.Forms.Padding(7);
            this.AdditionalData.PlaceHolder = "AdditionalData";
            this.AdditionalData.Size = new System.Drawing.Size(203, 30);
            this.AdditionalData.SystemPasswordChar = false;
            this.AdditionalData.TabIndex = 5;
            this.AdditionalData.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.AdditionalData.TextBoxText = "";
            this.AdditionalData.UnderlinedStyle = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(78, 210);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 22);
            this.button4.TabIndex = 6;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(6, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 68);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operations";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(138, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 42);
            this.button3.TabIndex = 8;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(72, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 42);
            this.button2.TabIndex = 7;
            this.button2.Text = "Insert";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Modify";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(3, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 240);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(123, 30);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 240);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox3
            // 
            this.listBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 15;
            this.listBox3.Location = new System.Drawing.Point(243, 30);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 240);
            this.listBox3.TabIndex = 2;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(123, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(243, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Department";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdditionalData2
            // 
            this.AdditionalData2.BackColor = System.Drawing.SystemColors.Window;
            this.AdditionalData2.BorderColor = System.Drawing.Color.DimGray;
            this.AdditionalData2.BorderWidth = 2;
            this.AdditionalData2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.AdditionalData2.Location = new System.Drawing.Point(6, 166);
            this.AdditionalData2.Name = "AdditionalData2";
            this.AdditionalData2.Padding = new System.Windows.Forms.Padding(7);
            this.AdditionalData2.PlaceHolder = "AdditionalData2";
            this.AdditionalData2.Size = new System.Drawing.Size(203, 30);
            this.AdditionalData2.SystemPasswordChar = false;
            this.AdditionalData2.TabIndex = 5;
            this.AdditionalData2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.AdditionalData2.TextBoxText = "";
            this.AdditionalData2.UnderlinedStyle = true;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(591, 318);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private NTextBox DataID;
        private NTextBox DataName;
        private NTextBox DataDepartment;
        private GroupBox groupBox1;
        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private GroupBox groupBox2;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button4;
        private NTextBox AdditionalData;
        private NTextBox AdditionalData2;
    }
}
