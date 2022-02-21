using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

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
        //A simple function for check data
        public static bool checkIfDataExist(MySqlConnection conn, RowType rowType, String username = "", String email = "", string location = "", bool isProfessional = false)
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
                Console.WriteLine(to_check);
                if (reader.GetString(RowTypeUtils.RowTypeInt(rowType)) == to_check)
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