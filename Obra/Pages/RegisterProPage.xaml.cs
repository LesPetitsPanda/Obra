using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using mySQLConnect;
using mySQLConnectio;
using System.Windows.Navigation;
using Obra.Utils;
using System;
using System.IO;
using System.Text.Json;
using Obra.SQLTools.ProfessionalAccount;

namespace Obra.Pages
{
    public partial class RegisterProPage : Page
    {
        public RegisterProPage()
        {
            InitializeComponent();

        }
        private void Register_OnClick(object sender, RoutedEventArgs e)
        {
           
            if (PasswordBox.Password != PasswordBoxAgain.Password)
            {
                PopupPasswordAgain.IsOpen = true;
            }
            if (PasswordBox.Password.Length <= 7)
            {
                PopupPassword.IsOpen = true;
            }
            if (SQLConnectUtility.checkIfDataExist(App.ConnectUtility.Connection, RowType.USERNAME, usernameBox.Text))
            {
                PopupUsername.IsOpen = true;
            }
            if (SQLConnectUtility.checkIfDataExist(App.ConnectUtility.Connection, RowType.EMAIL, "", emailBox.Text))
            {
                PopupEmail.IsOpen = true;
            }

            if (PopupEmail.IsOpen == false && PopupPassword.IsOpen == false && PopupUsername.IsOpen == false
                 && PopupPasswordAgain.IsOpen == false
                 && usernameBox.Text != null
                 && PasswordBox.Password != null
                 && emailBox.Text != null)
            {
             
                ProfessionalAccount professional = new ProfessionalAccount(App.connection, usernameBox.Text, PasswordBox.Password, firstnameBox.Text, emailBox.Text, Int32.Parse(phoneBox.Text));
                
            }

        }

        private void Popup_disabled(object sender, MouseButtonEventArgs e)
        {
            PopupPasswordAgain.IsOpen = false;
            PopupPassword.IsOpen = false;
            PopupUsername.IsOpen = false;
            PopupEmail.IsOpen = false;
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/LoginPage.xaml", UriKind.Relative));
        }

    }
}