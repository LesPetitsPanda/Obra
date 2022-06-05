using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MySql.Data.MySqlClient;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.PdfViewer;

namespace Obra.Utils
{
    public class ProfileCV
    {
        private BitmapImage cv;
        public BitmapImage CV
        {
            get { return cv; }
            set { cv = value; }
        }

        public ProfileCV()
        {
            //SavePicture();
            if (App.Username != null)
            {
                BitmapImage img = LoadPicture(App.Username);
                this.cv = img;
            }
            else this.cv = null;
        }

        public void SetInitValue()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile("https://cdn.discordapp.com/attachments/665843427795009536/983102577719803964/cv.PNG"
                    , System.AppDomain.CurrentDomain.BaseDirectory + @"\cv.png");
            }
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + @"\cv.png");
            img.EndInit();
            this.cv = img;
            byte[] ImageData;
            FileStream fs = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + @"\cv.png", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            using (var conn = App.ConnectUtility.Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE professional SET CV = ?Image WHERE username = '" + App.Username + "';";
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
            img.UriSource = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + @"\" + newpath);
            img.EndInit();
            this.cv = img;
            string FileName = newpath;
            byte[] ImageData;
            using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                using (var conn = App.ConnectUtility.Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE professional SET CV = ?Image WHERE username = '" + App.Username + "';";
                        cmd.Parameters.Add("?Image", MySqlDbType.Blob);
                        cmd.Parameters["?Image"].Value = ImageData;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        public BitmapImage LoadPicture(string username)
        {
            using (MySqlConnection con = App.ConnectUtility.Connection)
            {
                con.Open();
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT CV FROM professional WHERE username = '" + username + "';";
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
                            while ((bytesRead = reader.GetBytes(reader.GetOrdinal("CV"), fieldOffset, buffer, 0, buffer.Length)) == buffer.Length)
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
