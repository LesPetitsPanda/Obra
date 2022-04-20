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
    /// Logique d'interaction pour MainPagePro.xaml
    /// </summary>
    public partial class MainPagePro : Page
    {
        
        private IDictionary<string,List<DateTime>> RDV_d = new Dictionary<string,List<DateTime>>();
        public IDictionary<string, List<DateTime>> dates
        {
            get { return RDV_d; }
        }
        public MainPagePro()
        {
            InitializeComponent();
        }
        public void Button_RDV (object sender, RoutedEventArgs e)
        {
            RDV();
        }
        public IDictionary<string, List<DateTime>> RDV()
        {
            IDictionary<string, List<DateTime>> r = new Dictionary<string, List<DateTime>>();
            Calendar c = this.FindName("date") as Calendar;
            if (c.SelectedDates != null)
            {
                string s = "";
                List<DateTime> temp = new List<DateTime>();
                foreach (DateTime date in c.SelectedDates)
                {
                  
                    temp.Add(date);
                }
                r.Add(s,temp);
            }
            else
            {
                MessageBoxResult selected = MessageBox.Show("Select date !");
            }
            RDV_d = r;
            return r;
        }
       
        
    }
}
