using Obra.Utils;
using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Obra.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
        if(Obra.App.ConnectUtility.VerifyPassword(PasswordBox.Password, usernameBox.Text))
         {
            log.Content = "login";
            if (App.ConnectUtility.isProfessional(usernameBox.Text))
                {
                    MainPageProEvent(sender, e);
                    SerializerUtils.SerializeObject(SerializerUtils.writeToJSON("bool", "ispro", "true"), App.userDataSer);
                }
            else
                {
                    MainPagePartEvent(sender, e);
                    SerializerUtils.SerializeObject(SerializerUtils.writeToJSON("bool", "ispro", "false"), App.userDataSer);

                }
                App.Username = usernameBox.Text;
                SerializerUtils.SerializeObject(SerializerUtils.writeToJSON("bool", "islogin", "true"), App.userDataSer);
                Localisation.Localize.GetIpOfUser();
            }
        else
         {
            log.Content = "not login";
         }
            Utils.SerializerUtils.SerializeObject(Utils.SerializerUtils.writeToJSON("string", "username", usernameBox.Text), "userlogin");

        }
        private void MainPageProEvent(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MainPagePro.xaml", UriKind.Relative));
        }

        private void MainPagePartEvent(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MainPagePart.xaml", UriKind.Relative));
        }
        private void RegisterPart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/RegisterPartPage.xaml", UriKind.Relative));
        }
        private void RegisterPro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/RegisterProPage.xaml", UriKind.Relative));
        }

    }
}