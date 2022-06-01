using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using mySQLConnect;
using Obra.TCPUtils;
using Obra.Utils;

namespace Obra
{
    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public readonly static string userDataSer = "userlogin"; 
        private static MySQLConnectUtility __connect;
        public static string connection = "server=162.19.74.161;database=world;username=val;port=3306;password=123456789";
        private static string username;
        private static ProfilePicture profilePicture;
        public static TcpClientUtils tcpClientUtils = new TcpClientUtils();

        public static ProfilePicture ProfilePicture
        {
            get { return profilePicture; }
            set { profilePicture = value; }
        }
        public static string Username
        {
            set { username = value; }
            get => username;
        }

        public static MySQLConnectUtility ConnectUtility
        {
            get => __connect;
        }
        
        public App()
        {
            username = (string)Utils.SerializerUtils.DeserializeObject("userlogin", "string", "username");
            __connect = new MySQLConnectUtility(connection);
            Uri iconUri = new Uri("pack://application:,,,/Resources/logo.ico", UriKind.RelativeOrAbsolute);
            
            //   tcpClientUtils.Connect();     
            profilePicture = new ProfilePicture();
        }

        
    }
}