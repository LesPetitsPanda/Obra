﻿using System;
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
    /// Logique d'interaction pour MainPagePro.xaml
    /// </summary>
    public partial class MainPagePro : Page
    {
        public MainPagePro()
        {
            InitializeComponent();
        }
        private void SettingsPro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/SettingsPro.xaml", UriKind.Relative));
        }
        
    }
}
