using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using mySQLConnectio;
using System.Collections.Generic;

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
        
  
        public bool AddUser(String user, String password, String email, bool isProfessional = false)
        {
            if (SQLConnectUtility.checkIfDataExist(conn, RowType.USERNAME, user) && SQLConnectUtility.checkIfDataExist(conn, RowType.EMAIL, email))
            {
                return false;
                
            }
            conn.Open();
            String sql = "INSERT INTO registration (username, password, email, isProfessional) VALUES ('" + user + "','" + SQLConnectUtility.Sha1(password)+ "','" + email + "','"+ isProfessional+"')";
         MySqlCommand cmd = new MySqlCommand(sql, conn);
         cmd.ExecuteNonQuery();
         conn.Close();
         return true;
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

        public bool UpdateData(String username, String email, DataUpdateType dataUpdateType,String new_data, String password)
        {
            if (VerifyPassword(password, username))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "registration";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.TableDirect;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString((int)RowType.EMAIL)== email || reader.GetString((int)RowType.USERNAME) == username)
                    {
                        String sql= "";
                        switch (dataUpdateType)
                        {
                            case DataUpdateType.EMAIL:
                                sql = "UPDATE registration SET " + DataUpdateType.EMAIL.GetString() + " = '" + new_data + "' WHERE " + DataUpdateType.USERNAME + " = '" + username+ "';";
                                
                                break;
                            case DataUpdateType.USERNAME:
                                sql = "UPDATE registration SET " + DataUpdateType.USERNAME.GetString() + " = '" + new_data + "' WHERE " + DataUpdateType.EMAIL + " = '" + password+ "';";
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
                }
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
            if (SQLConnectUtility.checkIfDataExist(conn, RowType.USERNAME, username))
            {
                conn.Open();
                String sql = "DELETE FROM registration WHERE " + DataUpdateType.USERNAME.GetString() +" = '" + username + "';";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            return false;
        }
        
    }
}