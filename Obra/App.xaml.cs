using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using mySQLConnect;

namespace Obra
{
    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static MySQLConnectUtility __connect;

        public static MySQLConnectUtility ConnectUtility
        {
            get => __connect;
        }
        
        public App()
        {
            __connect = new MySQLConnectUtility("server=localhost;user=root;database=world;port=3306;password=EUw3qS^XaPfz4U");
        }
    }
}