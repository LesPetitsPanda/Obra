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
using System.Drawing;


namespace Obra.Pages
{
    /// <summary>
    /// Logique d'interaction pour MainPagePro.xaml
    /// </summary>
    public partial class MainPagePro : Page
    {
        
        private IDictionary<string,List<DateTime>> RDV_d = new Dictionary<string,List<DateTime>>();
        public IDictionary<string, List<DateTime>> dates
        {
            get { return RDV_d; }
        }
        private List<string> Names = new List<string>();
        public List<string> names
        {
            get { return Names; }
        }
        public MainPagePro()
        {
            InitializeComponent();
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
        public void Button_RDV (object sender, RoutedEventArgs e)
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
               
                name = Microsoft.VisualBasic.Interaction.InputBox("Enter Name", "Name", s, -1, -1);
                names.Add(name);
                foreach (DateTime date in c.SelectedDates)
                {
                    temp.Add(date);
                }
                r.Add(name,temp);
                for(int i = 0; i < r.Count;i++)
                {
                    int j = 0;
                    while (j < r[names[i]].Count)
                    {
                        rep += r[names[i]][j].ToString(format[0]);
                        j += 1;
                    }
                    rep += " : " + names[i];
                    rep += "\n";
                }
                RD.Text = rep;
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
