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
    public partial class UserControl1 : UserControl
    {
        public ListBox IDBoxUserControls {get => listBox1; set { listBox1= value; this.Invalidate(); } }
        public DataTable IDBoxDataSource { get =>  (DataTable)listBox1.DataSource; set { listBox1.DataSource = value; this.Invalidate(); } }
        public string IDBoxDisplayMember { get => listBox1.DisplayMember; set { listBox1.DisplayMember= value; this.Invalidate(); } }
        public ListBox NameBoxUserControls { get => listBox1; set { listBox1 = value; this.Invalidate(); } }
        public DataTable NameBoxDataSource { get => (DataTable)listBox1.DataSource; set { listBox1.DataSource = value; this.Invalidate(); } }
        public string NameBoxDisplayMember { get => listBox1.DisplayMember; set { listBox1.DisplayMember = value; this.Invalidate(); } }
        public ListBox DepartmentBoxUserControls { get => listBox1; set { listBox1 = value; this.Invalidate(); } }
        public DataTable DepartmentBoxDataSource { get => (DataTable)listBox1.DataSource; set { listBox1.DataSource = value; this.Invalidate(); } }
        public string DepartmentBoxDisplayMember { get => listBox1.DisplayMember; set { listBox1.DisplayMember = value; this.Invalidate(); } }

        public Button ModifyButton { get => button1; set { button1= value; this.Invalidate(); } }
        public Button InsertButton { get => button2; set { button2= value; this.Invalidate(); } }
        public Button DeleteButton { get => button3; set { button3 = value; this.Invalidate(); }  }

        public string IDTextBox { get => DataID.TextBoxText; set { DataID.TextBoxText= value; this.Invalidate(); } }
        public string NameTextBox { get => DataName.TextBoxText; set { DataName.TextBoxText= value; this.Invalidate(); } }
        public string DepartmentTextBox { get => DataDepartment.TextBoxText; set
            {
                DataDepartment.TextBoxText = value;
                this.Invalidate();
            }  }

        public bool firstRun = true;
        private ListBox invisibleList = new ListBox();
        private ListBox AdvisorinvisList = new ListBox();
        public string AdditionalDataPlaceHolder { get => AdditionalData.PlaceHolder; set { AdditionalData.PlaceHolder = value; this.Invalidate(); } }
        public string AdditionalDataTBox { get => AdditionalData.TextBoxText; set { AdditionalData.TextBoxText = value; this.Invalidate(); } }
        public bool AdditionalDataTBoxVisible { get => AdditionalData.Visible; set { AdditionalData2.Visible = value; this.Invalidate(); } }
        public string AdvisorDataTBox { get => AdditionalData2.TextBoxText; set { AdditionalData2.TextBoxText = value; this.Invalidate(); } }
        public bool AdvisorDataTBoxVisible { get => AdditionalData2.Visible; set { AdditionalData2.Visible = value; this.Invalidate(); } }

        public string Lb1 { get => label1.Text; set { label1.Text = value; this.Invalidate(); } }   
        public string Lb2 { get => label2.Text; set { label2.Text = value; this.Invalidate(); } }
        public string formType; 
        public TextBox DataIDBoxUserControls { get => DataID.TBoxUserControls;  set { DataID.TBoxUserControls = value; this.Invalidate(); } }
        public TextBox DepartmentIDBoxUserControls { get => DataDepartment.TBoxUserControls; set { DataDepartment.TBoxUserControls = value; this.Invalidate(); } }

        public UserControl1()
        {
            Controls.Add(invisibleList);
            Controls.Add(AdvisorinvisList);
            AdvisorinvisList.Visible = false; 
            invisibleList.Visible = false;
            invisibleList.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            AdvisorinvisList.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            InitializeComponent();
        }

        public void setDataTable(DataTable dataTable)
        {
            setListBoxes(dataTable);
            SetMember();

        }

        private void SetMember()
        {
            listBox1.DisplayMember = "ID";
            listBox2.DisplayMember = "NAME";
            listBox3.DisplayMember = "DEPARTMENT";
            invisibleList.DisplayMember = "ADD_DATA";
            AdvisorinvisList.DisplayMember = "ADD_DATA2";
        }


        private void setListBoxes(DataTable dataTable)
        {
            listBox1.DataSource = dataTable;

            listBox2.DataSource = dataTable;

            listBox3.DataSource = dataTable;

            invisibleList.DataSource = dataTable;

            AdvisorinvisList.DataSource = dataTable; 
        }

        public void setTexts(string type)
        {
            if(firstRun && type == "advisor") 
            {
                DataID.PlaceHolder = "Advisor ID";
                DataName.PlaceHolder = "Advisor Name";
                DataDepartment.PlaceHolder = "Student ID";
                AdditionalData.PlaceHolder = "Student Name";
                AdditionalData2.PlaceHolder = "Department";
                DataName.ReadOnly = true;
                AdditionalData.ReadOnly = true;

            }
            if(type != "advisor")
            {
                if (!firstRun)
                {
                    DataID.TextBoxText = listBox1.GetItemText(listBox1.SelectedItem);
                    DataName.TextBoxText = listBox2.GetItemText(listBox2.SelectedItem);
                    DataDepartment.TextBoxText = listBox3.GetItemText(listBox3.SelectedItem);
                    AdditionalData.TextBoxText = invisibleList.GetItemText(invisibleList.SelectedItem);
                    return;
                }
            }
            if (!firstRun)
            {
                DataID.TextBoxText = AdvisorinvisList.GetItemText(AdvisorinvisList.SelectedItem); //Advisor ID
                //DataName.TextBoxText = listBox2.GetItemText(listBox2.SelectedItem); //Advisor Name
                DataDepartment.TextBoxText = invisibleList.GetItemText(invisibleList.SelectedItem); //Student ID
                //AdditionalData.TextBoxText = listBox1.GetItemText(listBox1.SelectedItem); //Student Name
                AdditionalData2.TextBoxText = listBox3.GetItemText(listBox3.SelectedItem); //Department
                return;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTexts(formType);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataID.TextBoxText = string.Empty;
            DataName.TextBoxText = string.Empty;
            DataDepartment.TextBoxText = string.Empty;
            AdditionalData.TextBoxText = string.Empty;
            AdditionalData2.TextBoxText = string.Empty; 
        }

       
    }
}
