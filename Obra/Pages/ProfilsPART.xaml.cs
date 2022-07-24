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
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class ProfilsPART : Page
    {
        private IDictionary<string, List<DateTime>> RDV_d = new Dictionary<string, List<DateTime>>();
        public IDictionary<string, List<DateTime>> dates
        {
            get { return RDV_d; }
        }
        private List<string> Names = new List<string>();
        public List<string> names
        {
            get { return Names; }
        }
        public ProfilsPART()
        {
            InitializeComponent();
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
            ns.Navigate(new Uri("Pages/MessageManager.xaml", UriKind.Relative));
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/ProfilsPART.xaml", UriKind.Relative));
        }
        private void Message(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/MessagePart.xaml", UriKind.Relative));
        }
        public void Button_Favorite(object sender, RoutedEventArgs e)
        {
            Favorite();
        }
        public List<string> Favorite()
        {
            List<string> listname = new List<string>();
            string s = "";
            string n = "";
            n = Microsoft.VisualBasic.Interaction.InputBox("Enter Name", "Name", s, -1, -1);
            listname.Add(n);
            if (n == null && n == "")
            {
                listname.Remove(n);
                MessageBoxResult selected = MessageBox.Show("The name can't be empty !");

            }
            F.Inlines.Add(n + "\n");
            Names = listname;
            return names;
        }

        public void Button_RDV(object sender, RoutedEventArgs e)
        {
            RDV();
        }
        public IDictionary<string, List<DateTime>> RDV()
        {
            IDictionary<string, List<DateTime>> r = new Dictionary<string, List<DateTime>>();
            Calendar c = this.FindName("date") as Calendar;
            String[] format = { "d" };
            if (c.SelectedDates.Count != 0)
            {
                string s = "";
                string name = "";
                string rep = "";
                List<DateTime> temp = new List<DateTime>();
            }
            else
            {
                MessageBoxResult selected = MessageBox.Show("Select a date !");
            }
            RDV_d = r;
            return r;
        }
    }
}