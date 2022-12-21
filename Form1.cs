using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        ConnectionSettings MySettings;
        SQLCon MyCon;
        public Form1()
        {
            MySettings = new ConnectionSettings("");
            MyCon = new SQLCon(MySettings);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MyCon.SelectQuery("*", "student");
            if(MyCon.getErrorCode() < 0 ) { button1.Text = "Works"; }
            this.Text = MyCon.getError();
        }
    } 
}