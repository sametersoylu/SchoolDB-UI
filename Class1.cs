using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    internal class SQLCon
    {
        internal class ConnectionSettings
        {
            private string _server = "", _db = "", _user = "", _pwd = "";
            private string conString = "";
            public string server { get { return _server; } set { _server = value; } }
            public string db { get { return _db; } set { _db = value; } }
            public string user { get { return _user; } set { _user = value; } }
            public string pwd { get { return _pwd; } set { _pwd = value; } }
            private string set_Settings(string Server, string DB, string User, string Password)
            {
                _server = Server;
                _db = DB;
                _user = User;
                _pwd = Password;
                conString = $"Server={server}; Database={db}; uid={user}; Password={pwd}";
                return $"Server={server}; Database={db}; uid={user}; Password={pwd}";
            }
            public ConnectionSettings(string Password)
            {
                set_Settings("localhost", "SchoolDB", "root", Password);
            }

            public ConnectionSettings(string SERVER, string DB, string USER, string PASSWORD)
            {
                set_Settings(SERVER, DB, USER, PASSWORD);
            }
            public string get_Settings()
            {
                return conString;
            }
           
        }
        
        ConnectionSettings conSettings = new ConnectionSettings("159951");
        /* MySQL CONNECTION VARIABLES */
        MySqlConnection con;
        MySqlDataAdapter connector;
        MySqlCommand cmd;
        /* MySQL CONNECTION VARIABLES */
        private string ErrorStr = "";
        private string lastusedTable = "";
        /* OVERLOADED FUNCTION AS PARAMETERED CONSTRUCTOR */
        public SQLCon(string Server, string Database, string User, string Password)
        {
            con = new MySqlConnection(conSettings.get_Settings());
            connector = new MySqlDataAdapter();
            cmd = new MySqlCommand();
        }

        /* OVERLOAD FUNCTION AS BASIC CONSTRUCTOR */
        public SQLCon()
        {
            
            con = new MySqlConnection(conSettings.get_Settings());
            connector = new MySqlDataAdapter();
            cmd = new MySqlCommand();
        }

        //THIS FUNCTIONS SOLE PURPOSE IS RUNNING SIMPLE SELECT QUERIES AND RETURNING DATA TABLE FROM THEM
        public DataTable SelectQuery(string Columns, string Table, string Where = "")
        {
            
            string Query;
            DataTable dataTable = new DataTable();
            if(Where == "")
            {
                Query = $"select {Columns} from {Table};";
            }
            else { Query = $"select {Columns} from {Table} where {Where};"; }
            cmd.CommandText = Query;
            cmd.Connection = con;
            connector.SelectCommand = cmd;
            lastusedTable = Table; 
            try
            {
                con.Open();
                connector.Fill(dataTable);
                ErrorStr = "";
            }
            catch (Exception ex)
            {
                ErrorStr= ex.Message;
            }
            con.Close();
            return dataTable;
        }

        //THIS FUNCTIONS SOLE PURPOSE IS RUNNING QUERIES AND RETURNING DATA TABLE FROM THEM
        public DataTable AdvancedQuery(string Query)
        {
            DataTable dataTable = new DataTable();
            cmd.CommandText = Query;
            cmd.Connection = con;
            connector.SelectCommand = cmd;
            try
            {
                con.Open();
                connector.Fill(dataTable);
                ErrorStr = "";
            }
            catch(Exception ex) {
                ErrorStr = ex.Message;
            }
            con.Close();
            return dataTable;
        }

        public string getError()
        {
            switch(getErrorCode())
            {
                case 0:
                    return "No error."; 
                case -1:
                    return $"{lastusedTable} doesn't exist.";
                case -2:
                    return "Connection is already open.";
                default:
                    return $"Undefined error! Error string is \"{ErrorStr}\" ";
            }
        }
        public int getErrorCode()
        {
            if($"Table '{conSettings.db.ToLower()}.{lastusedTable}' doesn't exist" == ErrorStr) {
                return -1; 
            }
            if($"The connection is already open." == ErrorStr)
            {
                return -2; 
            }
            if(ErrorStr != "")
            {
                return 1; 
            }
            return 0; 
        }
    }
}
