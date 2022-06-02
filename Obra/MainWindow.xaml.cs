using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Obra.Pages;
using Obra.Utils;

namespace Obra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
           Uri iconUri = new Uri("pack://application:,,,/Resources/mainlogo.ico", UriKind.RelativeOrAbsolute);
           this.Icon = BitmapFrame.Create(iconUri);
               /* if(SerializerUtils.DeserializeObject(App.userDataSer, "bool", "islogin") == null)
                 {
                     this.Source = new Uri("Pages/LoginPage.xaml", UriKind.Relative);
                 }
                 else
                if((string)SerializerUtils.DeserializeObject(App.userDataSer, "bool", "islogin") == "true")
                 {
                     if ( SerializerUtils.DeserializeObject(App.userDataSer, "bool", "ispro") == "true")
                     {
                         this.Source = new Uri("Pages/MainPagePro.xaml", UriKind.Relative);
                     }
                     else
                     {
                         this.Source = new Uri("Pages/MainPagePart.xaml", UriKind.Relative);
                     }

                 }
                 else
                 {
                     this.Source = new Uri("Pages/LoginPage.xaml", UriKind.Relative);
                 }*/
               this.Source = new Uri("Pages/LoginPage.xaml", UriKind.Relative);

        }

        protected override void OnClosed(EventArgs args)
        {
            if (File.Exists("userip"))
            {
                File.Delete("userip");
            }
          base.OnClosed(args);
          Application.Current.Dispatcher.InvokeShutdown();
          //  App.tcpClientUtils.Close();
        }
    }
}