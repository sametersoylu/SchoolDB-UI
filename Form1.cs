using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        ConnectionSettings MySettings;
        SQLCon MyCon;
        DataTable Tables_of_DB = new DataTable();
        Form2 LogInForm; 
        public Form1(string selectedSchema, DataTable Tables, string DB_USER,string DB_PASS, Form2 logInForm) 
        {
            MySettings = new ConnectionSettings("localhost", selectedSchema, DB_USER, DB_PASS);
            MyCon = new SQLCon(MySettings);
            Tables_of_DB = Tables;
            LogInForm = logInForm; 
            InitializeComponent();
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = Tables_of_DB;
            listBox1.DisplayMember = $"Tables_in_{MySettings.db}";
            dataGridView1.DataSource = Tables_of_DB; 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogInForm.Close();
        }
    } 
}