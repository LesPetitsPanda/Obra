﻿using Obra.Utils;
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
            ns.Navigate(new Uri("Pages/MessagePro.xaml", UriKind.Relative));
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/ProfilsPRO.xaml", UriKind.Relative));
        }
        private void Username(object sender, RoutedEventArgs e)
        {
            
        }
        private void Job(object sender, RoutedEventArgs e)
        {
            
        }
        private void Email(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
