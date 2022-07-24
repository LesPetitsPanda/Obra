using MySql.Data.MySqlClient;
using mySQLConnectio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Obra.Utils
{
    public class ProfilePicture
    {
 

        private BitmapImage img;

        public BitmapImage Image
        {
            get { return img; }
            set { img = value; }
        }
        
        public ProfilePicture()
        {
            //SavePicture();
            if (App.Username != null)
            {
                BitmapImage img = LoadPicture(App.Username);
                this.img = img;
            }
            else this.img = null;
        }

        public void SetInitValue()
        {
            using(WebClient webClient = new WebClient())
            {
                webClient.DownloadFile("https://media.discordapp.net/attachments/915700925065203776/968893962637172736/Desktop_-_2-3-removebg-preview.png"
                    , System.AppDomain.CurrentDomain.BaseDirectory + @"\profile.png");
            }
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + @"\profile.png");
            img.EndInit();
            this.img = img;
            byte[] ImageData;
            FileStream fs = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + @"\profile.png", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            using (var conn = App.ConnectUtility.Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE registration SET pdp = ?Image WHERE username = '" + App.Username + "';";
                    //cmd.CommandText = "INSERT INTO registration (pdp) VALUES (?Image);";
                    cmd.Parameters.Add("?Image", MySqlDbType.Blob);
                    cmd.Parameters["?Image"].Value = ImageData;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

        }

        public void SavePicture(string newpath)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(newpath);
            img.EndInit();
            this.img = img;
            string FileName = newpath;
            byte[] ImageData;
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            using (var conn = App.ConnectUtility.Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE registration SET pdp = ?Image WHERE username = '" + App.Username + "';";
                    cmd.Parameters.Add("?Image", MySqlDbType.Blob);
                    cmd.Parameters["?Image"].Value = ImageData;
                    cmd.ExecuteNonQuery();
                }
            conn.Close();
            }
        }

        public BitmapImage LoadPicture(string username)
        {
            using (MySqlConnection con = App.ConnectUtility.Connection)
            {
                con.Open();
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT pdp FROM registration WHERE username = '" + username + "';";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        const int CHUNK_SIZE = 2 * 1024;
                        byte[] buffer = new byte[CHUNK_SIZE];
                        long bytesRead;
                        long fieldOffset = 0;
                        using (var stream = new MemoryStream())
                        {
                            while ((bytesRead = reader.GetBytes(reader.GetOrdinal("pdp"), fieldOffset, buffer, 0, buffer.Length)) == buffer.Length)
                            {
                                stream.Write(buffer, 0, (int)bytesRead);
                                fieldOffset += bytesRead;
                            }
                            var bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.StreamSource = new MemoryStream(stream.ToArray());
                            bitmapImage.EndInit();
                            con.Close();
                            return bitmapImage;
                        }
                    }
                }
            }
            return null;
        }
    }
}
