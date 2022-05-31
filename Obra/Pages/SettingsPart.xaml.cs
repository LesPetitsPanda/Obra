using Microsoft.Win32;
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
            Loaded += SettingsPart_Loaded;
        }

        private void SettingsPart_Loaded(object sender, RoutedEventArgs e)
        {
            UsernameBox.Text = App.Username;
            EmailBox.Text = App.ConnectUtility.getData(App.Username, mySQLConnectio.RowType.EMAIL);
            PasswordBox.Text = "***************";
            Loaded -= SettingsPart_Loaded;

        }

        private void disconnectEvent(object sender, RoutedEventArgs args)
        {
            SerializerUtils.SerializeObject(SerializerUtils.writeToJSON("bool", "islogin", "false"), App.userDataSer);
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/LoginPage.xaml", UriKind.Relative));
        }
        private void SettingsPart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/SettingsPart.xaml", UriKind.Relative));
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MainPagePart.xaml", UriKind.Relative));
        }
        private void Message_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MessagePart.xaml", UriKind.Relative));
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/ProfilsPART.xaml", UriKind.Relative));
        }
        private void Username(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageBoxResult messageBox = MessageBox.Show("You are about to change your username. Are you sure ?", "Warning", MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    App.ConnectUtility.UpdateData(App.Username, "", mySQLConnectio.DataUpdateType.USERNAME, UsernameBox.Text);
                    SerializerUtils.SerializeObject(SerializerUtils.writeToJSON("string", "username", UsernameBox.Text), App.userDataSer);
                    App.Username = UsernameBox.Text;
                }
                else
                {
                    UsernameBox.Text = App.Username;
                }

            }
        }
        private void Password(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageBoxResult messageBox = MessageBox.Show("You are about to change your password. Are you sure ?", "Warning", MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    App.ConnectUtility.UpdateData(App.Username, "", mySQLConnectio.DataUpdateType.PASSWORD, PasswordBox.Text);
                }
                else
                {
                    PasswordBox.Text = "*******";
                }

            }
        }
        private void Email(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageBoxResult messageBox = MessageBox.Show("You are about to change your email. Are you sure ?", "Warning", MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    App.ConnectUtility.UpdateData(App.Username, "", mySQLConnectio.DataUpdateType.EMAIL, EmailBox.Text);
                }
                else
                {
                    EmailBox.Text = App.ConnectUtility.getData(App.Username, mySQLConnectio.RowType.EMAIL);
                }

            }
        }

        private void Change_Picture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|(*.png)|*.png|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                App.ProfilePicture.SavePicture(selectedFileName);
            }

        }
    }
}
