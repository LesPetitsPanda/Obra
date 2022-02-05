using MySql.Data.MySqlClient;
using mySQLConnect;

namespace Obra.SQLTools.Professional
{
    public class ProfessionalAccount
    {
        protected MySQLConnectUtility _connect;
        public static MySqlConnection conn;
        private string url = "";
        public ProfessionalAccount(string email, string password, string username, string name, string adresse,
            string pays, string birth_day)
        {
            _connect = new MySQLConnectUtility("");
            _connect.AddUser(username, password);
            
        }
    }
}