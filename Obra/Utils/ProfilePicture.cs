using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Obra.Utils
{
    public class ProfilePicture
    {
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public ProfilePicture(string path)
        {
            this.path = path;
        }

        public void SavePicture()
        {

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    MySqlConnection con = App.ConnectUtility.conn;
                    string query = "INSERT INTO registration(pdp, pdp_size) VALUES (@Content, @Size)";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Size", (int)fs.Length);
                        cmd.Parameters.AddWithValue("@Content", bytes);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        public BitmapImage LoadPicture()
        {
            using (MySqlConnection con = App.ConnectUtility.Connection)
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.TableDirect;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(1) == App.Username)
                        {
                           // reader.GetBytes(8);
                        }
                    }
                }
            }
            return null;
        }
    }
}
