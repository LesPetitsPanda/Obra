using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using mySQLConnect;

namespace Obra
{
    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public readonly static string userDataSer = "logindata"; 
        private static MySQLConnectUtility __connect;
        public static string connection = "server=localhost;user=root;database=world;port=3306;password=EUw3qS^XaPfz4U";

        public static MySQLConnectUtility ConnectUtility
        {
            get => __connect;
        }
        
        public App()
        {
            
            __connect = new MySQLConnectUtility(connection);
            Uri iconUri = new Uri("pack://application:,,,/Resources/logo.ico", UriKind.RelativeOrAbsolute);
                
        }

        
    }
}