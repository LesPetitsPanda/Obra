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
    /// Logique d'interaction pour MessageManager.xaml
    /// </summary>
    public partial class MessageManager : Page
    {
        public MessageManager()
        {
            InitializeComponent();
        }

        private void SettingsPart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            if (App.ConnectUtility.isProfessional(App.Username))
            {
                ns.Navigate(new Uri("Pages/SettingsPro.xaml", UriKind.Relative));
            }
            else
            {
                ns.Navigate(new Uri("Pages/SettingsPart.xaml", UriKind.Relative));
            }
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            if (App.ConnectUtility.isProfessional(App.Username))
            {
                ns.Navigate(new Uri("Pages/MainPagePro.xaml", UriKind.Relative));
            }
            else { ns.Navigate(new Uri("Pages/MainPagePart.xaml", UriKind.Relative)); }
        }
        private void Message_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MessagePart.xaml", UriKind.Relative));
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            if (App.ConnectUtility.isProfessional(App.Username))
            {
                ns.Navigate(new Uri("Pages/ProfilsPRO.xaml", UriKind.Relative));
            }
            else
            {
                ns.Navigate(new Uri("Pages/ProfilsPART.xaml", UriKind.Relative));
            }
        }

        private void Username1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            MessagePart message = new MessagePart();
            message.UserToSend = "Joseph";
            ns.Navigate(message);
        }
    }
}
