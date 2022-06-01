using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using mySQLConnectio;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace mySQLConnect
{
    public class MySQLConnectUtility
    {
        public MySqlConnection conn;

        //Carefull with this getter, can be null
        public MySqlConnection Connection
        {
            get => conn;
        }
        
        public MySQLConnectUtility(String connexion)
        {
            conn = new MySqlConnection(connexion);
        }
        public MySQLConnectUtility(MySqlConnection connexion)
        {
            conn = connexion;
        }

        public bool isProfessional(string username)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "registration";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetBoolean((int)RowType.PROFESSIONAL) && reader.GetString((int)RowType.USERNAME) == username)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }

        public bool AddUser(String user, String password, String email, int code, bool isProfessional = false)
        {
            if (SQLConnectUtility.checkIfDataExist(conn, RowType.USERNAME, user, "","") ||
                SQLConnectUtility.checkIfDataExist(conn, RowType.EMAIL, email, "", ""))
            {
                return false;

            }
            else
            {
                int pro = isProfessional ? 1 : 0;
                conn.Open();
                String sql = "INSERT INTO registration (username, password, email, isProfessional, code, pdp) VALUES ('" + user +
                             "','" + SQLConnectUtility.Sha1(password) + "','" + email + "','" + pro + "','" + code + "','" +  "000" + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool CheckCode(string user, int code)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "registration";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString((int)RowType.USERNAME) == user)
                {
                    if (reader.GetString(6) == code.ToString())
                    {
                        conn.Close();
                        string sql = "UPDATE registration SET " + "code = '" +
                            "-1" + "' WHERE " + DataUpdateType.USERNAME + " = '" +
                            user + "';";
                        MySqlCommand command = new MySqlCommand(sql, conn);
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }
                }
            }
            return false;
        }
        public bool AddLocation(string user, string iplocation)
        {
            if (SQLConnectUtility.checkIfDataExist(conn, RowType.USERNAME, user))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "registration";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.TableDirect;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(reader.GetString((int)RowType.USERNAME) == user)
                    {
                        string sql = "UPDATE registration SET " + DataUpdateType.LOCATION.GetString() + " = '" + iplocation + "' WHERE " + DataUpdateType.USERNAME + " = '" + user + "';";
                        MySqlCommand cmd2 = new MySqlCommand(sql,conn);
                        cmd2.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                conn.Close();
            }
           
            return false;
        }

        public Dictionary<string,string> getDataOfColumnMatchUsername(RowType row, bool isProfessional = false)
        {
            Dictionary<string,string> string_data = new Dictionary<string, string>();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "registration";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetBoolean(5) == isProfessional)
                {
                    string_data.Add(reader.GetString((int)RowType.USERNAME), reader.GetString((int)RowType.LOCATION));
                }
            }
            conn.Close();
            return string_data;
        }

        public string getLocation(string name)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "registration";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(1) == name)
                {
                  string res = reader.GetString((int)RowType.LOCATION);
                  conn.Close();
                  return res;
                }
            }
            conn.Close();
            return null;
        }
  

        public bool VerifyPassword(String password, String user)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "registration";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if (reader.GetString((int)RowType.USERNAME) == user)
                {
                    if (reader.GetString((int)RowType.PASSWORD) == SQLConnectUtility.Sha1(password))
                    {
                        conn.Close();
                        return true;
                       
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }
                }
            }
            conn.Close();
            return false;
        }

        public bool UpdateData(String username, String email, DataUpdateType dataUpdateType,String new_data, String password="")
        {
            if (SQLConnectUtility.checkIfDataExist(conn, RowType.USERNAME, username))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "registration";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.TableDirect;
                        String sql= "";
                        switch (dataUpdateType)
                        {
                            case DataUpdateType.EMAIL:
                                sql = "UPDATE registration SET " + DataUpdateType.EMAIL.GetString() + " = '" + new_data + "' WHERE " + DataUpdateType.USERNAME + " = '" + username+ "';";
                                
                                break;
                            case DataUpdateType.USERNAME:
                                sql = "UPDATE registration SET " + DataUpdateType.USERNAME.GetString() + " = '" + new_data + "' WHERE " + DataUpdateType.USERNAME + " = '" + username+ "';";
                                break;
                            case DataUpdateType.PASSWORD:
                                sql = "UPDATE registration SET " + DataUpdateType.PASSWORD.GetString() + " = '" + SQLConnectUtility.Sha1(new_data) + "' WHERE " + DataUpdateType.USERNAME + " = '" + username + "';";
                                break;
                            default:
                                conn.Close();
                                return false;
                        }
                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.ExecuteNonQuery();
                        conn.Close();
                        return true;
            }
            if (SQLConnectUtility.checkIfDataExist(conn, RowType.USERNAME, username) && password == "")
            {
                conn.Open();
                String sql = "UPDATE registration SET " + DataUpdateType.PASSWORD.GetString() + " = '" + SQLConnectUtility.Sha1(new_data) + "' WHERE " + DataUpdateType.USERNAME + " = '" + username + "';";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Vous pouvez supprimer une ligne de la base de donnée avec le username
        /// </summary>
        /// <remarks>
        /// <para>
        /// Attention à ne pas utiliser n'importe ou / n'importe comment
        /// 
        /// 
        /// </para>
        /// <para>
        /// This class is thread-safe.  All members may be used by multiple threads concurrently.
        /// </para>
        /// </remarks>
        public bool DeleteRow(String username)
        {
                conn.Open();
                String sql = "DELETE FROM registration WHERE " + DataUpdateType.USERNAME.GetString() +" = '" + username + "';";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                return true;
           
        }
        public string getData(string username, RowType rowType)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "registration";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(1) == username)
                {
                    string res = reader.GetString((int)rowType);
                    conn.Close();
                    return res;
                }
            }
            conn.Close();
            return null;
        }
        
    }
}