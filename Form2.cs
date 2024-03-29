﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json; 

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        int a = 3;
        private bool conState = false;
        private bool readJson = true; 
        ConnectionSettings newSetting = new ConnectionSettings("","","","");
        string database = string.Empty;
        Form1 MenuForm;
        Form2 LogInForm; 
        SQLCon newCon = new SQLCon("","","",""); 
        public Form2()
        {
            LogInForm = this;
            MenuForm = new Form1("","","","", LogInForm);
            InitializeComponent();
        }
     

        private void readServConf()
        {
            try
            {
                using (StreamReader r = new StreamReader("servconfig.json"))
                {
                    string json = r.ReadToEnd();
                    dynamic array = JsonConvert.DeserializeObject(json);
                    foreach (var item in array)
                    {
                        newSetting = new ConnectionSettings(item.host.ToString(), item.db.ToString(), item.user.ToString(), item.password.ToString());
                    }
                }
                readJson = true;
            }
            catch (Exception ex)
            {
                readJson = false;
            }
            
        }

        public void cleanForm()
        {
            Run();
            comboBox1.DataSource = new List<string>();
            nTextBox1.TextBoxText = string.Empty;
            nTextBox2.TextBoxText = string.Empty;
            nTextBox1.Enabled = true; nTextBox2.Enabled = true;
            button1.Text = "Bağlan";
        }

        private void Run()
        {
            conState = false;
            comboBox1.Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Run();
            readServConf();
            
            if(readJson)
            {
                LogInForm = this;
                MenuForm = new Form1(newSetting.db, newSetting.server, newSetting.user, newSetting.pwd, LogInForm);
                newCon = new SQLCon(newSetting);
                newCon.ModifyQuery("show schemas;");
                timer1.Start();
            }
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
            }
        }

        private bool checkLoginBoxes()
        {
            if (nTextBox1.TextBoxText == string.Empty && nTextBox2.TextBoxText == string.Empty)
            { MessageBox.Show("Username and password can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (nTextBox1.TextBoxText == string.Empty)
            { MessageBox.Show("Username can't be empty!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (nTextBox2.TextBoxText == string.Empty)
            { MessageBox.Show("Password can't be empty!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!checkLoginBoxes()) { return; }
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
                MessageBox.Show(newCon.getError(), "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            LogInForm = this;
            MenuForm = new Form1(database, newSetting.server, newSetting.user, newSetting.pwd, LogInForm);
            MenuForm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label4.Text == "Connection Failed!")
            {
                panel1.Visible = false;
                timer1.Stop();
            }
            label4.Text += ".";
            a--;
            System.Diagnostics.Debug.WriteLine($"{a}");
            if(a == 0)
            {
                if(newCon.getErrorCode() != 0) { 
                    MessageBox.Show(newCon.getError(), "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    timer1.Stop();
                    label4.Text = "Connection Failed!";
                    a = 3;
                    timer1.Start();
                    return; }
                MenuForm.Show();
                this.Hide();
                a = 3;
                timer1.Stop();
            }
        }
    }
}
