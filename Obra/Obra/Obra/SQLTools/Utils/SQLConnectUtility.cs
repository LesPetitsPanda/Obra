using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace mySQLConnectio
{
    public class SQLConnectUtility
    {
        public static string Sha1(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            byte[] outbuffer = cryptoTransformSHA1.ComputeHash(buffer);
            return Convert.ToBase64String(outbuffer);
        }
        public static bool checkIfDataExist(MySqlConnection conn, RowType rowType, String username = "", String email = "")
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "registration";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            String to_check = username;
            if (rowType == RowType.EMAIL)
            {
                to_check = email;
            }
            while(reader.Read())
            {
                if (reader.GetString((int)rowType) == to_check)
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