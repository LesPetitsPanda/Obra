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
    /// Logique d'interaction pour SettingsPro.xaml
    /// </summary>
    public partial class SettingsPro : Page
    {
        public SettingsPro()
        {
            InitializeComponent();
            Loaded += SettingsPro_Loaded;
        }

        private void SettingsPro_Loaded(object sender, RoutedEventArgs e)
        {
            UsernameBox.Text = App.Username;
            EmailBox.Text = App.ConnectUtility.getData(App.Username, mySQLConnectio.RowType.EMAIL);
            PasswordBox.Text = "***************";
            pdp_Name.Source = App.ProfilePicture.Image;
            JobBox.Text = mySQLConnectio.SQLConnectUtility.getJob(App.Username, App.ConnectUtility.conn);
            RateBox.Text = mySQLConnectio.SQLConnectUtility.getRate(App.Username, App.ConnectUtility.conn);
            CityBox.Text = Localisation.Localize.GetCityByIp(App.ConnectUtility.getLocation(App.Username));
            Loaded -= SettingsPro_Loaded;
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
            ns.Navigate(new Uri("Pages/SettingsPro.xaml", UriKind.Relative));
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MainPagePro.xaml", UriKind.Relative));
        }
        private void Message_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MessageManager.xaml", UriKind.Relative));
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/ProfilsPRO.xaml", UriKind.Relative));
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
                pdp_Name.Source = App.ProfilePicture.Image;
            }

        }
        private void JobBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
