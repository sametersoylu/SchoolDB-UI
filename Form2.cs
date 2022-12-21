using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private bool conState = false;
        ConnectionSettings newSetting;
        DataTable Tables = new DataTable();
        string database = string.Empty;
        Form1 MenuForm;
        Form2 LogInForm; 
        SQLCon newCon; 
        public Form2()
        {
            
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
             
            conState = false; 
            comboBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(conState)
            {
                database = comboBox1.Text;
                if(newCon.getErrorCode() != 0) 
                {
                    MessageBox.Show(newCon.getError());
                    return; 
                }
                Tables = newCon.GetTables(database);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!conState)
            {
                newSetting = new ConnectionSettings("localhost", "", nTextBox1.TextBoxText, nTextBox2.TextBoxText);
                newCon = new SQLCon(newSetting);
                comboBox1.DataSource = newCon.GetSchemas();
                comboBox1.DisplayMember = "Database";
                if (newCon.getErrorCode() == 0)
                {
                    button1.Text = "Çalıştır";
                    nTextBox1.Enabled = false;
                    nTextBox2.Enabled = false;
                    comboBox1.Enabled = true; 
                    conState = true;
                    return; 
                }
                conState = false; 
                MessageBox.Show(newCon.getError());
            }
            LogInForm = this;
            MenuForm = new Form1(database, Tables, newSetting.user, newSetting.pwd, LogInForm);
            MenuForm.Show();
            this.Hide();
        }
    }
}
