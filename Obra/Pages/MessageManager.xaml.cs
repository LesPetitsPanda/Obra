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
    /// Logique d'interaction pour MessageManager.xaml
    /// </summary>
    public partial class MessageManager : Page
    {
        public MessageManager()
        {
            InitializeComponent();
            Loaded += MessageManager_Loaded;
        }

        private void MessageManager_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in Utils.MessageManagerUtils.getList("managemessage"))
            {
                list_add.Children.Add(createBlock(s));
            }
        }

        private void SettingsPart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            if (App.ConnectUtility.isProfessional(App.Username))
            {
                ns.Navigate(new Uri("Pages/SettingsPro.xaml", UriKind.Relative));
            }
            else
            {
                ns.Navigate(new Uri("Pages/SettingsPart.xaml", UriKind.Relative));
            }
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            if (App.ConnectUtility.isProfessional(App.Username))
            {
                ns.Navigate(new Uri("Pages/MainPagePro.xaml", UriKind.Relative));
            }
            else { ns.Navigate(new Uri("Pages/MainPagePart.xaml", UriKind.Relative)); }
        }
        private void Message_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MessageManager.xaml", UriKind.Relative));
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            if (App.ConnectUtility.isProfessional(App.Username))
            {
                ns.Navigate(new Uri("Pages/ProfilsPRO.xaml", UriKind.Relative));
            }
            else
            {
                ns.Navigate(new Uri("Pages/ProfilsPART.xaml", UriKind.Relative));
            }
        }

        private void Username1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            MessagePart message = new MessagePart();
            message.UserToSend = "Joseph";
            ns.Navigate(message);
        }
        private Border createBlock(string username)
        {
            string[] s =  username.Split('\n');
            Border border = new Border();
            border.Height = 50;
            border.BorderThickness = new Thickness(1.5);
            border.BorderBrush = Brushes.Black;
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s[0];
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(textBlock, 0);
            grid.Children.Add(textBlock);
            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = "Metier: " + s[1];
            textBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(textBlock1, 1);
            grid.Children.Add(textBlock1);
            border.Child = grid;
            border.MouseDown += (sender, args) => {
                MessagePart messagePart = new MessagePart();
                messagePart.UsertoSend = textBlock.Text;
                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(messagePart);
            };
            return border;
        }
  
    }
}
