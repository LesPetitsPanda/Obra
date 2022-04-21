using Obra.Algorithm;
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
            Loaded += SearchUpdate;
        }

        private void SettingsPart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Pages/SettingsPart.xaml", UriKind.Relative));
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        { 
        }
        private void Message_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Keyboard.ClearFocus();
                ResearchDone();
            }
        }

        private void OnSearchClick(object sender, EventArgs e)
        {
            TextBlock? first = this.FindName("first_result") as TextBlock;
            TextBlock? second = this.FindName("second_result") as TextBlock;
            TextBlock? third = this.FindName("third_result") as TextBlock;
            first.Inlines.Clear();
            second.Inlines.Clear();
            third.Inlines.Clear();

        }
        private void SearchUpdate(object sender, EventArgs args)
        {

          
            TextBlock? first = this.FindName("first_result") as TextBlock;
            TextBlock? second = this.FindName("second_result") as TextBlock;
            TextBlock? third= this.FindName("third_result") as TextBlock;
            List<Tuple<string, string>> lastresearch = LastResearch.getThreeLastResearch();
            if (lastresearch.Count > 0 && lastresearch[0] is not null && first is not null)
            {
                first.Inlines.Add(new Run(lastresearch[0].Item1) { FontWeight = FontWeights.Bold});
                first.Inlines.Add(new LineBreak());
                first.Inlines.Add(new Run(lastresearch[0].Item2));
            }
            else first.Inlines.Clear();
            if (lastresearch.Count > 1 && lastresearch[1] is not null && second is not null)
            {
                second.Inlines.Add(new Run(lastresearch[1].Item1) { FontWeight = FontWeights.Bold });
                first.Inlines.Add(new LineBreak());
                second.Inlines.Add(new Run(lastresearch[1].Item2));
            }
            else second.Inlines.Clear();
            if (lastresearch.Count > 2 && lastresearch[2] is not null && third is not null)
            {
                third.Inlines.Add(new Run(lastresearch[2].Item1) { FontWeight = FontWeights.Bold });
                first.Inlines.Add(new LineBreak());
                third.Inlines.Add(new Run(lastresearch[2].Item2));
            }
            else third.Inlines.Clear();

            Loaded -= SearchUpdate;
        }

        private void ResearchDone()
        {
            TextBlock? first = this.FindName("first_result") as TextBlock;
            TextBlock? second = this.FindName("second_result") as TextBlock;
            TextBlock? third = this.FindName("third_result") as TextBlock;
            TextBox? research = this.FindName("search") as TextBox;
            if(mySQLConnectio.SQLConnectUtility.checkIfDataExist(App.ConnectUtility.conn,mySQLConnectio.RowType.USERNAME, research.Text, "","", true))
            {
                first.Inlines.Add(new Run(research.Text) { FontWeight = FontWeights.Bold });
                first.Inlines.Add(new LineBreak());
                first.Inlines.Add(new Run(mySQLConnectio.SQLConnectUtility.getJob(research.Text, App.ConnectUtility.conn)));
            }
            else { 


                first.Inlines.Add(new Run("User or job not found !") { FontWeight = FontWeights.Bold});
            
            }
            
            
            
            
            
           // Individual individual = new Individual(Localisation.Localize.GetIpOfUser());
         //   individual.getProfessionalByLocation();
        }

    }
}
