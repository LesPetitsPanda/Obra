using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using Obra;

namespace mySQLConnectio
{
    public class SQLConnectUtility
    {
        //SimpleHash (256 bits maybe)
        // property
        public static string Sha1(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new();
            byte[] outbuffer = cryptoTransformSHA1.ComputeHash(buffer);
            return Convert.ToBase64String(outbuffer);
        }
        public static string getJob(string name, MySqlConnection conn)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "professional";
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read.GetString(1) == name)
                {
                    string res = read.GetString(8);
                    conn.Close();
                    return res;
                }
            }
            conn.Close();
            return null;
        }
        public static void addRate(string name, MySqlConnection conn, string rate)
        { string s = getTotalRate(name, conn);
            string sql;
            if (s == "-1")
            {
               sql = "UPDATE professional SET " + "rate" + " = '" + rate + "' WHERE " + DataUpdateType.USERNAME + " = '" + name + "';";

            }
            else
            {
                sql  = "UPDATE professional SET " + "rate" + " = '" + s + ","+rate + "' WHERE " + DataUpdateType.USERNAME + " = '" + name + "';";
            }
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        private static string getTotalRate(string name, MySqlConnection conn)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "professional";
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read.GetString(1) == name)
                {
                    string res = read.GetString(6);
                    conn.Close();
                    return res;
                }
            }
            conn.Close();
            return null;
        }
        public static string getRate(string name, MySqlConnection conn)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "professional";
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read.GetString(1) == name)
                {
                    string res = read.GetString(6);
                    conn.Close();
                    string[] temp = res.Split(new char[] {','});
                    int rate = 0;
                    foreach(string s in temp)
                    {
                        if(s == "-1")
                        {
                            return "Without rate";
                        }
                        else
                        {
                            rate+= int.Parse(s);
                        }
                    }
                    return (rate/temp.Length).ToString();
                }
            }
            conn.Close();
            return null;
        }

        public static List<string> getName(string job, MySqlConnection conn)
        {
            List<string> res = new List<string>();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "professional";
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read.GetString(8) is not null && read.GetString(8) == job)
                {
                  res.Add(read.GetString(1));
                }
            }
            conn.Close();
            return res;
        }

        //A simple function for check data
        public static bool checkIfDataExist(MySqlConnection conn, RowType rowType, string username = "", string email = "", string location = "",bool isProfessional = false)
        {
            
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            if (isProfessional)
            {
                cmd.CommandText = "professional";
            }
            else
            {
                cmd.CommandText = "registration";
            }
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            String to_check = username;
            if (rowType == RowType.EMAIL)
            {
               to_check = email;    
            }
            if(rowType == RowType.LOCATION)
            {
                to_check = location;
            }
            if (to_check == "") {
                conn.Close();
                return false; }
            
            while (reader.Read())
            {
                if (reader.GetString(RowTypeUtils.RowTypeInt(rowType)) == to_check && (isProfessional||(reader.GetString(RowTypeUtils.RowTypeInt(RowType.CODE)) == "-1")))
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
    }
}