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
        ConnectionSettings conSettings;
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
            conSettings = new ConnectionSettings(Server, Database, User, Password);
            con = new MySqlConnection(conSettings.get_Settings());
            connector = new MySqlDataAdapter();
            cmd = new MySqlCommand();
        }

        /* OVERLOAD FUNCTION AS BASIC CONSTRUCTOR */
        public SQLCon(string Password)
        {
            conSettings = new ConnectionSettings(Password);
            con = new MySqlConnection(conSettings.get_Settings());
            connector = new MySqlDataAdapter();
            cmd = new MySqlCommand();
        }

        public SQLCon(ConnectionSettings ConSet) {  
            conSettings = ConSet;
            con = new MySqlConnection(conSettings.get_Settings());
            connector = new MySqlDataAdapter();
            cmd = new MySqlCommand();
        }  

        public SQLCon(string server ,string user, string password)
        {
            conSettings = new ConnectionSettings(server, "", user, password);
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

        public DataTable GetTables(string DB)
        {   
            DataTable dataTable = new DataTable();
            cmd.CommandText = $"USE {DB}; SHOW TABLES;"; 
            cmd.Connection = con;
            connector.SelectCommand = cmd;
            try
            {
                con.Open();
                connector.Fill(dataTable);
                ErrorStr = "";
            }
            catch(Exception ex)
            {
                ErrorStr = ex.Message; 
            }
            con.Close();
            return dataTable; 
        }

        

        public DataTable GetSchemas()
        {   
            DataTable dataTable = new DataTable();
            cmd.CommandText = "SHOW SCHEMAS;"; 
            cmd.Connection = con;  
            connector.SelectCommand = cmd;
            try
            {
                con.Open();
                connector.Fill(dataTable);
                ErrorStr = "";
            }
            catch (Exception ex) 
            {
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
