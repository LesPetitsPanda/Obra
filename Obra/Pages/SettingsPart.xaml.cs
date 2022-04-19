using Obra.Utils;
using System;
using System.Collections.Generic;
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

namespace Obra.Pages
{
    /// <summary>
    /// Logique d'interaction pour SettingsPart.xaml
    /// </summary>
    public partial class SettingsPart : Page
    {
        public SettingsPart()
        {
            InitializeComponent();
        }
        private void disconnectEvent(object sender, RoutedEventArgs args)
        {
            SerializerUtils.SerializeObject(SerializerUtils.writeToJSON("bool", "islogin", "false"), App.userDataSer);
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/LoginPage.xaml", UriKind.Relative));
        }
        
    }
}
