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
        Form2 LogInForm;
        Form3 DataForm; 
        DataGridView newGrid = new DataGridView();  
        DataTable newData= new DataTable();

        string columnName = "";
        string selectedTable = "";
        string keyWord = "";
        string columnAs = "";

        private bool LogOut = false; 
        private bool MenuState = false; 
        private bool DataGridState = false;
        private bool DataGridDock = false;
        private bool searchPanelState = false; 

        public Form1(string selectedSchema, string DB_HOST, string DB_USER,string DB_PASS, Form2 logInForm) 
        {
            MySettings = new ConnectionSettings("localhost", selectedSchema, DB_USER, DB_PASS);
            MyCon = new SQLCon(MySettings);
            DataForm = new Form3("", "", "", "");
            LogInForm = logInForm;
            InitializeComponent();
        } 

   

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            this.AutoSize = true;
            try
            {
                comboBox1.SelectedIndex = 0;
            } 
            catch (Exception ex) { ex.ToString(); }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!LogOut)
            {
                LogInForm.Close();
                return; 
            }
            LogInForm.cleanForm();
            LogInForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            LogOut = true;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!MenuState)
            {
                MenuState = true;
                panel1.Visible = MenuState;
                return; 
            }
            MenuState= false;
            panel1.Visible = MenuState;
            return; 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataForm = new Form3("student", MySettings.db, MySettings.user, MySettings.pwd);
            DataForm.Show();
        }
        private void createDataGridView()
        {
            if (DataGridState)
            {
                panel2.Controls.Remove(newGrid);
                newGrid = new DataGridView();
                DataGridState = false;
            }
            if (MyCon.getErrorCode() != 0)
            {
                MessageBox.Show(MyCon.getError(), "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(DataGridDock)
            {
                newGrid.Dock = DockStyle.Fill;
            }
            newGrid.AutoSize = true;
            if (!DataGridState)
            {
                this.AutoSize = true;
                panel2.AutoSize = true;
                newGrid.Location = new Point(0, 0);
                newGrid.BackgroundColor = Color.White;
                newGrid.Dock = DockStyle.Fill; 
                panel2.Controls.Add(newGrid);
                DataGridState = true;
                
            }
            if(searchPanelState)
            {
                panel3.Visible = false;
                searchPanelState = false;   
            }
        }
        private void PrintAQuery(string query) 
        {
            createDataGridView();
            newData = MyCon.AdvancedQuery(query);
            if (MyCon.getErrorCode() != 0) { MessageBox.Show(MyCon.getError()); return; }
            newGrid.DataSource = newData;
            this.Size = new Size(panel2.Width + 135, panel2.Height + 60);
        }
        private void PrintASelectQuery(string column, string table, string where = "")
        {
            createDataGridView();
            newData = MyCon.SelectQuery(column, table, where);
            if(MyCon.getErrorCode() != 0) { MessageBox.Show(MyCon.getError()); return;  }
            newGrid.DataSource = newData;
            this.Size = new Size(panel2.Width + 135, panel2.Height + 60);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            DataForm = new Form3("instructor", MySettings.db, MySettings.user, MySettings.pwd);
            DataForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataForm = new Form3("advisor", MySettings.db, MySettings.user, MySettings.pwd);
            DataForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintASelectQuery("building_name as Buildings", "building");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrintASelectQuery("title as CourseName, course_id as CourseCode, dept_name as Department, credits as Credits", "course");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            AutoSize = false;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(!searchPanelState)
            {
                comboBox1.DataSource = MyCon.AdvancedQuery("select * from tables where activity <= 1 order by id asc;");
                comboBox1.DisplayMember = "table_name";
                panel3.Visible = true;
                panel3.Dock = DockStyle.Fill;
                searchPanelState= true;
                return; 
            }
            searchPanelState = false;
            panel3.Visible = false; 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("You have to choose a table.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            columnName = "";
            columnAs = ""; 
            selectedTable = ""; 
            keyWord = textBox1.Text;
            switch (comboBox1.SelectedIndex) 
            {
                case 1:
                    columnName = "title";
                    columnAs = "course_id as CourseCode, title as CourseName, dept_name as Department, credits as Credits";
                    selectedTable = "course";
                    break;
                case 2: columnName = "dept_name";
                    columnAs = "dept_name as Department, building as Building, budget as Budget";
                    selectedTable = "department";
                    break;
                case 3: columnName = "i_name";
                    columnAs = "instructor_id as InstructorID, i_name as Instructor, dept_name as Department, salary as Salary";
                    selectedTable = "instructor";
                    break;
                case 4: columnName = "s_name";
                    columnAs = "student_id as StudentID, s_name as StudentName, dept_name as Department, total_cred as TotalCredit";
                    selectedTable = "student";
                    break;
                default:
                    break;
            }
            newData = MyCon.SelectQuery(columnAs, selectedTable, $"{columnName} like '%{keyWord}%'");
            if (MyCon.getErrorCode() != 0) { MessageBox.Show(MyCon.getError()); }
            if (newData.Rows.Count == 0)
            {
                MessageBox.Show($"No entry found for keyword: '{keyWord}' in '{selectedTable}'.");
                return;
            }
            createDataGridView();
            newGrid.DataSource = newData;
            this.Size = new Size(panel2.Width + 135, panel2.Height + 60);
            panel3.Visible = false;
            searchPanelState = false;
            textBox1.Clear();
            this.Text = MyCon.lastusedTable; 
        }

       
    } 
}