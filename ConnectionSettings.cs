using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class ConnectionSettings
    {
        private string _server = "", _db = "", _user = "", _pwd = "";
        private string conString = "";
        private string conStringNoDB = ""; 
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
            conStringNoDB = $"Server={server}; uid={user}; Password={pwd};"; 
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
            if(_db == "")
            {
                return conStringNoDB; 
            }
            return conString;
        }
    }
}
