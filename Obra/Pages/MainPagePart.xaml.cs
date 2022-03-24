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
    /// Logique d'interaction pour MainPagePart.xaml
    /// </summary>
    public partial class MainPagePart : Page
    {
        public MainPagePart()
        {
            InitializeComponent();
        }
        private void SettingsPart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/SettingsPart.xaml", UriKind.Relative));
        }

        private void Marteau(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/SettingsPart.xaml", UriKind.Relative));
        }
    }
}
