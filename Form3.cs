using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        private string FormType;

        private SQLCon con;

        public Form3(string FormType, string selectedDB, string user, string password)
        {
            this.FormType = FormType;
            con = new SQLCon("localhost",selectedDB, user, password);
            InitializeComponent();

        }
        private void Run()
        {
            RenewList();
            uc1.ModifyButton.Click += ModifyButton;
            uc1.InsertButton.Click += InsertButton;
            uc1.DeleteButton.Click += DeleteButton;
            uc1.firstRun = false;
            
        }

        private void idchanged(object sender, EventArgs e)
        {
            if(uc1.IDTextBox != string.Empty)
            {
                ListBox invisbox = new ListBox();
                DataTable dataTable;
                dataTable = con.SelectQuery("i_name as NAME", "instructor", $"instructor_id = {uc1.IDTextBox}");
                if(con.getErrorCode() != 0)
                {
                    this.Text = con.getError();
                }
                invisbox.DataSource = dataTable;
                invisbox.DisplayMember = "NAME";
                if(invisbox.Items.Count >= 0 )
                {
                    Controls.Add(invisbox);
                    invisbox.Visible = false;
                    try
                    {
                        invisbox.SelectedIndex = 0;
                    }
                    catch(Exception ex)
                    {
                        
                    }
                    uc1.NameTextBox = invisbox.GetItemText(invisbox.SelectedItem);
                }
            }
        }
        private void idchanged2(object sender, EventArgs e)
        {
            if (uc1.DepartmentTextBox != string.Empty)
            {
                ListBox invisbox = new ListBox();
                DataTable dataTable;
                dataTable = con.SelectQuery("s_name as NAME", "student", $"student_id = {uc1.DepartmentTextBox}");
                if (con.getErrorCode() != 0)
                {
                    this.Text = con.getError();
                }
                invisbox.DataSource = dataTable;
                invisbox.DisplayMember = "NAME";
                if (invisbox.Items.Count >= 0)
                {
                    Controls.Add(invisbox);
                    invisbox.Visible = false;
                    try
                    {
                        invisbox.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        
                    }
                    uc1.AdditionalDataTBox = invisbox.GetItemText(invisbox.SelectedItem);
                }
                return; 
            }
            
        }

        private void RenewList() 
        {
            if(FormType == "student")
            {
                DataTable data = new DataTable();
                data = con.SelectQuery("student_id as ID, s_name as NAME, dept_name as DEPARTMENT, total_cred as ADD_DATA", "student");
                uc1.setDataTable(data);
                this.Text = "Student";
                uc1.AdvisorDataTBoxVisible = false;
                uc1.AdditionalDataPlaceHolder = "Total Credits";
            }
            if(FormType == "instructor")
            {
                DataTable data = new DataTable();
                data = con.SelectQuery("instructor_id as ID, i_name as NAME, dept_name as DEPARTMENT, salary as ADD_DATA", "instructor");
                uc1.setDataTable(data);
                this.Text = "Instructor";
                uc1.AdvisorDataTBoxVisible = false;
                uc1.AdditionalDataPlaceHolder = "Salary";
            }
            if(FormType == "advisor")
            {
                DataTable data = new DataTable();
                data = con.AdvancedQuery("select S.s_name as ID, I.i_name as NAME, A.department_name as DEPARTMENT, S.student_id as ADD_DATA, I.instructor_id as ADD_DATA2 from student S, " +
                    "instructor I, advisor A where A.instructor_id = I.instructor_id and S.student_id = A.student_id;");
                if (con.getErrorCode() != 0)
                {
                    MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                uc1.setDataTable(data);
                this.Text = "Advisor";
                uc1.AdditionalDataPlaceHolder = "Department";
                uc1.AdvisorDataTBoxVisible = true; 
                uc1.Lb1 = "Student"; uc1.Lb2 = "Advisor";
                uc1.AdditionalDataTBoxVisible = true;
                uc1.setTexts(FormType);
                uc1.formType = "advisor";
                uc1.DataIDBoxUserControls.TextChanged += idchanged;
                uc1.DepartmentIDBoxUserControls.TextChanged += idchanged2;
            }
        }
        private bool checkIDBoxes()
        {
            if (uc1.IDTextBox == string.Empty || uc1.NameTextBox == string.Empty || uc1.DepartmentTextBox == string.Empty)
            { MessageBox.Show("You should fill the required boxes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            return true;
        }

        private void Modify(string type)
        {
            if (type == "student" && checkIDBoxes())
            {
                if(con.ModifyQuery($"update student set " +
                    $"student_id = {uc1.IDTextBox}, s_name = \"{uc1.NameTextBox}\", " +
                    $"dept_name = \"{uc1.DepartmentTextBox}\", total_cred = {uc1.AdditionalDataTBox} where student_id = " +
                    $"{uc1.IDBoxUserControls.GetItemText(uc1.IDBoxUserControls.SelectedItem)};"))
                {
                    MessageBox.Show("Item has succesfully modified!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    RenewList();
                    return;
                }
                MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            if (type == "instructor" && checkIDBoxes())
            {
                if(con.ModifyQuery($"update instructor set " +
                    $"instructor_id = {uc1.IDTextBox}, i_name = \"{uc1.NameTextBox}\", " +
                    $"dept_name = \"{uc1.DepartmentTextBox}\", salary = {uc1.AdditionalDataTBox} where instructor_id = " +
                    $"{uc1.IDBoxUserControls.GetItemText(uc1.IDBoxUserControls.SelectedItem)};"))
                {
                    MessageBox.Show("Item has succesfully modified!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RenewList();
                    return;
                }
                MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (type == "advisor" && checkIDBoxes())
            {
                if(con.ModifyQuery($"update advisor set instructor_id = {uc1.IDTextBox}, student_id = {uc1.DepartmentTextBox}, department_name = \"{uc1.AdvisorDataTBox}\"" +
                    $"where instructor_id = {uc1.IDTextBox} and student_id = {uc1.DepartmentTextBox};"))
                {
                    MessageBox.Show("Item has succesfully modified!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RenewList();
                    return;
                }
                MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void Insert(string type)
        {
            if(type == "student" && checkIDBoxes())
            {
                if(con.ModifyQuery($"insert into student values ({uc1.IDTextBox}, \"{uc1.NameTextBox}\",\"{uc1.DepartmentTextBox}\",{uc1.AdditionalDataTBox});"))
                {
                    MessageBox.Show("Item has been succesfully inserted to the table!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RenewList();
                    return;
                }
                MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (type == "instructor" && checkIDBoxes())
            {
                if (con.ModifyQuery($"insert into instructor values ({uc1.IDTextBox}, \"{uc1.NameTextBox}\",\"{uc1.DepartmentTextBox}\",{uc1.AdditionalDataTBox});"))
                {
                    MessageBox.Show("Item has been succesfully inserted to the table!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RenewList();
                    return;
                }
                MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (type == "advisor" && checkIDBoxes())
            {
                if(con.ModifyQuery($"insert into advisor values({uc1.IDTextBox}, {uc1.DepartmentTextBox}, \"{uc1.AdvisorDataTBox}\");"))
                {
                    MessageBox.Show("Item has been succesfully inserted to the table!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RenewList();
                    return;
                }
            }
            MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void Delete(string type)
        {
            if(type == "student")
            {
                if (con.ModifyQuery($"delete from student where student_id = {uc1.IDTextBox};"))
                {
                    MessageBox.Show("Item has been successfully deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information); RenewList();
                    return;
                }
                MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            if(type == "instructor")
            {
                if (con.ModifyQuery($"delete from instructor where instructor_id = {uc1.IDTextBox};"))
                {
                    MessageBox.Show("Item has been successfully deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information); RenewList();
                    return;
                }
                MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            if(type == "advisor")
            {
                if (con.ModifyQuery($"delete from advisor where instructor_id = {uc1.IDTextBox} and student_id = {uc1.DepartmentTextBox};"))
                {
                    MessageBox.Show("Item has been successfully deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information); RenewList();
                    return;
                }
                MessageBox.Show(con.getError(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
        }

        private void ModifyButton(object sender, EventArgs e)
        {
            Modify(FormType);
        }
        private void InsertButton(object sender, EventArgs e)
        {
            Insert(FormType);
        }
        private void DeleteButton(object sender, EventArgs e)
        {
            Delete(FormType);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            uc1.AutoSize = true;
            
            Run();
        }
    }
}
