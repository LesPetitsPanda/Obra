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

        private void login_Click(object sender, RoutedEventArgs e)
        {
        if(Obra.App.ConnectUtility.VerifyPassword(PasswordBox.Password, usernameBox.Text))
         {
            log.Content = "login";
            Console.Write("okkk");
            MainPageProEvent(sender,e);
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
        private void register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/RegisterPage.xaml", UriKind.Relative));
        }
    }
}