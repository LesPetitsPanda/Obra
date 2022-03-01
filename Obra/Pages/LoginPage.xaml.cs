using System;
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
            Console.Write("okkk");
            if (App.ConnectUtility.isProfessional(usernameBox.Text))
                {
                    MainPageProEvent(sender, e);
                }
            else
                {
                    MainPagePartEvent(sender, e);
                }
            }
        else
         {
            log.Content = "not login";
         }
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