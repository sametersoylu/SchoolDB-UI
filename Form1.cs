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
        DataGridView newGrid = new DataGridView();  
        DataTable newData= new DataTable();

        string columnName = "";
        string selectedTable = "";
        string keyWord = "";
        string columnAs;
        private bool LogOut = false; 
        private bool MenuState = false; 
        private bool DataGridState = false;
        private bool DataGridDock = false;
        private bool searchPanelState = false; 
        private bool searchPanelDock = false;

        public Form1(string selectedSchema, DataTable Tables, string DB_USER,string DB_PASS, Form2 logInForm) 
        {
            MySettings = new ConnectionSettings("localhost", selectedSchema, DB_USER, DB_PASS);
            MyCon = new SQLCon(MySettings);
            Tables_of_DB = Tables;
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
            catch (Exception ex) { }
            
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
            PrintASelectQuery("student_id as StudentID, s_name as StudentName", "student");
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
            newGrid.DataSource = newData;
            this.Size = new Size(panel2.Width + 135, panel2.Height + 60);
        }
        private void PrintASelectQuery(string column, string table, string where = "")
        {
            createDataGridView();
            newData = MyCon.SelectQuery(column, table, where);
            if(MyCon.getErrorCode() != 0) { MessageBox.Show(MyCon.getError()); }
            MessageBox.Show(searchPanelState.ToString());
            if(newData.Rows.Count == 0 && searchPanelState) 
            {
                MessageBox.Show($"No entry found for keyword: {keyWord} in .");
            }
            newGrid.DataSource = newData;
            this.Size = new Size(panel2.Width + 135, panel2.Height + 60);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            PrintASelectQuery("instructor_id as InstructorID, i_name as InstructorName", "instructor");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintAQuery("select S.s_name as StudentName, I.i_name as Advisor from student S, " +
                "instructor I, advisor A where A.instructor_id = I.instructor_id and S.student_id = A.student_id;");
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
                    columnAs = " as CourseName";
                    selectedTable = "course";
                    break;
                case 2: columnName = "dept_name";
                    columnAs = " as Department";
                    selectedTable = "department";
                    break;
                case 3: columnName = "i_name";
                    columnAs = " as Instructor";
                    selectedTable = "instructor";
                    break;
                case 4: columnName = "s_name";
                    columnAs = " as StudentName";
                    selectedTable = "student";
                    break;
                default:
                    break;
            }

           
            newData = MyCon.SelectQuery(columnName + columnAs, selectedTable, $"{columnName} like '%{keyWord}%'");
            if (MyCon.getErrorCode() != 0) { MessageBox.Show(MyCon.getError()); }
            if (newData.Rows.Count == 0)
            {
                MessageBox.Show($"No entry found for keyword: {keyWord} in {selectedTable}.");
                return;
            }

            createDataGridView();
            newGrid.DataSource = newData;
            this.Size = new Size(panel2.Width + 135, panel2.Height + 60);
            panel3.Visible = false;
            searchPanelState = false;
            this.Text = MyCon.lastusedTable; 
        }
    } 
}