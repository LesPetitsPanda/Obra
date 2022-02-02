using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using mySQLConnectio;

namespace mySQLConnect
{
    public class MySQLConnectUtility
    {
        public static MySqlConnection conn;

        public MySQLConnectUtility(String connexion)
        {
            conn = new MySqlConnection(connexion);
        }
        
  
        public bool AddUser(String user, String password)
        {
            if (SQLConnectUtility.checkIfDataExist(conn, RowType.USERNAME, user))
            {
                return false;
                
            }
            conn.Open();
            String sql = "INSERT INTO registration (username, password) VALUES ('" + user + "','" + SQLConnectUtility.Sha1(password)+ "')";
         MySqlCommand cmd = new MySqlCommand(sql, conn);
         cmd.ExecuteNonQuery();
         conn.Close();
         return true;
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

        public bool UpdateData(String username, String email, DataUpdateType dataUpdateType,String new_data, String password = "")
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