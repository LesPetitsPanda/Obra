using MySql.Data.MySqlClient;
using mySQLConnect;
using mySQLConnectio;
using System;
using System.Collections.Generic;

namespace Obra.SQLTools.ProfessionalAccount
{
    public class ProfessionalAccount
    {
        public MySqlConnection conn;
        private string _username;
        private string _password;
        private string _email;
        private string _firstName;
        private int _telephone;
        private int _rate;

        public string Username { get { return _username; } }
        public string Password { get { return _password; } }
        public string Email { get { return _email; } }
        public string FirstName { get { return _firstName; } }
        public int Telephone { get { return _telephone; } }
        public int Rate { get { return _rate; } set { _rate = value; } }

        private MySQLConnectUtility _mySQLConnect;

        //Carefull with this getter, can be null
        public MySqlConnection Connection
        {
            get => conn;
        }

        public ProfessionalAccount(string connection, string username, string password, string firstname, string email, int telephone)
        {
            conn = new MySqlConnection(connection);
            _mySQLConnect = new MySQLConnectUtility(conn);
            _username = username;
            _password = password;
            _email = email;
            _firstName = firstname;
            _telephone = telephone;
            _rate = -1;
            AddProfessional();
            _password = mySQLConnectio.SQLConnectUtility.Sha1(password);

        }

        private bool AddProfessional()
        {
            if (_mySQLConnect.AddUser(_username, _password, Email, true) && SQLConnectUtility.checkIfDataExist(conn, RowType.USERNAME, Username, "", "", true))
            {
                conn.Open();
                string sql =
               "INSERT INTO professional (username, password, email, namefirstname, telephone, rate) VALUES ('" + Username + "','" + SQLConnectUtility.Sha1(Password) + "','" + Email + "','" + FirstName + "','" + Telephone + "','" + "','" + Rate + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            return false;
        }

        public Dictionary<string, int> getRate()
        {
            Dictionary<string, int> res = new();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                res.Add(reader.GetString(0), reader.GetInt32(5));
            }
            conn.Close();
            return res;
        }
        public bool updateDataType(DataUpdateType type, string username, string new_data = "", int new_data_int = 0)
        {
            string sql = "";
            switch (type)
            {
                case DataUpdateType.EMAIL:
                    sql = "UPDATE professional SET " + DataUpdateType.EMAIL.GetString() + " = '" + new_data + "' WHERE " + DataUpdateType.USERNAME + " = '" + username + "';";
                    break;
                case DataUpdateType.PASSWORD:
                    sql = "UPDATE professional SET " + DataUpdateType.PASSWORD.GetString() + " = '" + SQLConnectUtility.Sha1(new_data) + "' WHERE " + DataUpdateType.USERNAME + " = '" + username + "';";
                    break;
                case DataUpdateType.LOCATION:
                    sql = "UPDATE professional SET " + DataUpdateType.LOCATION.GetString() + " = '" + new_data + "' WHERE " + DataUpdateType.USERNAME + " = '" + username + "';";
                    break;
                case DataUpdateType.USERNAME:
                    sql = "UPDATE professional SET " + DataUpdateType.USERNAME.GetString() + " = '" + new_data + "' WHERE " + DataUpdateType.USERNAME + " = '" + username + "';";
                    break;
                case DataUpdateType.RATE:
                    sql = "UPDATE professional SET " + DataUpdateType.RATE.GetString() + " = '" + new_data_int + "' WHERE " + DataUpdateType.USERNAME + " = '" + username + "';";
                    break;
                case DataUpdateType.TELEPHONE:
                    sql = "UPDATE professional SET " + DataUpdateType.TELEPHONE.GetString() + " = '" + new_data_int + "' WHERE " + DataUpdateType.USERNAME + " = '" + username + "';";
                    break;
                default:
                    return false;
            }
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
    }
}