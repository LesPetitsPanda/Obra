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
                if (EmailManager.validMail(emailBox.Text))
                {
                    Confirm.IsOpen = true;
                    String code = RandomUtils.GenerateFourNum();
                    ProfessionalAccount professional = new ProfessionalAccount(App.connection, usernameBox.Text, PasswordBox.Password, firstnameBox.Text, emailBox.Text, Int32.Parse(phoneBox.Text), Int32.Parse(code));
                    EmailManager.SendEmailGmail(emailBox.Text, "Verification for Obra", "Hello, " + usernameBox.Text + "\n \n Your code is: " + code);
                    text_confirm.Text = "Check your mail box, you should receive a confirm email in this address:" + emailBox.Text;
                    confirm_register.KeyDown += Confirm_register_KeyDown;
                }
                else
                {
                    MessageBox.Show("Wrong Email Please put a right E-mail", "Retry", MessageBoxButton.OK);
                }
               
                
            }

        }
        private void Confirm_register_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.Key == Key.Enter && textBox.Text != "")
            {
                if (App.ConnectUtility.CheckCode(usernameBox.Text, Int32.Parse(textBox.Text)))
                {
                   var result = MessageBox.Show("The register is a success come back for login, before that, Can we use your geolocation data ?", "Connected", MessageBoxButton.YesNo);
                   if(result == MessageBoxResult.No)
                    {
                        App.Current.Shutdown();
                    } 
                   Confirm.IsOpen = false;

                }
            }
        }
        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            if (confirm_register.Text != "")
            {
                if (App.ConnectUtility.CheckCode(usernameBox.Text, Int32.Parse(confirm_register.Text)))
                {
                    MessageBox.Show("The register is a success come back for login", "Connected");
                    Confirm.IsOpen = false;
                }
                else
                {
                    MessageBox.Show("Wrong code, try again", "Error");
                }
            }
        }
        private void Cancelled_OnClick(object sender, RoutedEventArgs e)
        {
            App.ConnectUtility.DeleteRow(usernameBox.Text);
            Confirm.IsOpen = false;
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
            MessageBoxResult selected = MessageBox.Show("Obra needs your data location to be functional");
        }

    }
}