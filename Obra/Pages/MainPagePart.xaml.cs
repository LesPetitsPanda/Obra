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
            Loaded += Scrollable_ScrollChanged;
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

        private void ContentClickable(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            if (textBlock.Inlines.Count == 3)
#pragma warning disable CS8604 // Existence possible d'un argument de référence null.
                LastResearch.WriteResearch(((Run)textBlock.Inlines.ToArray()[0]).Text, ((Run)textBlock.Inlines.ToArray()[2]).Text);
                UpdateResearch();
#pragma warning restore CS8604 // Existence possible d'un argument de référence null.
            
        }

        private void Scrollable_ScrollChanged(object sender, EventArgs args)
        {
            var scrollViewer = this.FindName("Scrollable") as ScrollViewer;
            StackPanel? stackpanel = this.FindName("contentscroll") as StackPanel;
            if (scrollViewer != null)
            {
                Individual individual = new Individual(Localisation.Localize.GetIpOfUser());
                //MessageBox.Show(individual.getAllProfessionalLocation().First().Value +" "+ " " + individual.getAllProfessionalLocation().First().Key +individual.getAllProfessionalLocation().Count);
                Dictionary<string, string> dict = individual.getProfessionalByLocation(individual.getAllProfessionalLocation());
                foreach (var item in dict){
                    var textBlock = new TextBlock();
                    textBlock.MouseLeftButtonDown += ContentClickable;
                    textBlock.Inlines.Add(new Run(item.Key) { FontWeight = FontWeights.Bold });
                    textBlock.Inlines.Add(new LineBreak());
                    textBlock.Inlines.Add(new Run(mySQLConnectio.SQLConnectUtility.getJob(item.Key, App.ConnectUtility.conn)));
                    stackpanel.Children.Add(textBlock);
             
                }
            }
            scrollViewer.Content = stackpanel;
            Loaded -= Scrollable_ScrollChanged;
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

        private void UpdateResearch()
        {
            TextBlock? first = this.FindName("first_result") as TextBlock;
            TextBlock? second = this.FindName("second_result") as TextBlock;
            TextBlock? third = this.FindName("third_result") as TextBlock;
            first.Inlines.Clear();
            second.Inlines.Clear();
            third.Inlines.Clear();
            List<Tuple<string, string>> lastresearch = LastResearch.getThreeLastResearch();
            if (lastresearch.Count > 0 && lastresearch[0] is not null && first is not null)
            {
                first.Inlines.Add(new Run(lastresearch[0].Item1) { FontWeight = FontWeights.Bold });
                first.Inlines.Add(new LineBreak());
                first.Inlines.Add(new Run(lastresearch[0].Item2));
            }
            else first.Inlines.Clear();
            if (lastresearch.Count > 1 && lastresearch[1] is not null && second is not null)
            {
                second.Inlines.Add(new Run(lastresearch[1].Item1) { FontWeight = FontWeights.Bold });
                second.Inlines.Add(new LineBreak());
                second.Inlines.Add(new Run(lastresearch[1].Item2));
            }
            else second.Inlines.Clear();
            if (lastresearch.Count > 2 && lastresearch[2] is not null && third is not null)
            {
                third.Inlines.Add(new Run(lastresearch[2].Item1) { FontWeight = FontWeights.Bold });
                third.Inlines.Add(new LineBreak());
                third.Inlines.Add(new Run(lastresearch[2].Item2));
            }
            else third.Inlines.Clear();

        }

        private void SearchUpdate(object sender, EventArgs args)
        {
            UpdateResearch();
            Loaded -= SearchUpdate;
        }

        private void ResearchDone()
        {
            TextBlock? first = this.FindName("first_result") as TextBlock;
            TextBlock? second = this.FindName("second_result") as TextBlock;
            TextBlock? third = this.FindName("third_result") as TextBlock;
            TextBox? research = this.FindName("search") as TextBox;
            first.Inlines.Clear();
            second.Inlines.Clear();
            third.Inlines.Clear();
            if(mySQLConnectio.SQLConnectUtility.checkIfDataExist(App.ConnectUtility.conn,mySQLConnectio.RowType.USERNAME, research.Text, "","", true))
            {
                first.Inlines.Add(new Run(research.Text) { FontWeight = FontWeights.Bold });
                first.Inlines.Add(new LineBreak());
                first.Inlines.Add(new Run(mySQLConnectio.SQLConnectUtility.getJob(research.Text, App.ConnectUtility.conn)));
            }
            else {
                string job = research.Text;
                //MessageBox.Show(Localisation.Localize.GetDistanceBetween(Localisation.Localize.GetLocationByIp(Localisation.Localize.GetIpOfUser()), Localisation.Localize.GetLocationByIp("77.151.93.123")).ToString());
                Individual individual = new Individual(Localisation.Localize.GetIpOfUser());
                Dictionary<string, string> mapwithjob = individual.getNameJobMatchingUsername(job);
               
                Dictionary<string,string> mapwithlocation = new Dictionary<string,string>();
                foreach( var keypair in mapwithjob)
                {
                    mapwithlocation.Add(keypair.Key, App.ConnectUtility.getLocation(keypair.Key));
                }
                
                if (mapwithlocation.Count > 0)
                {
                    Dictionary<string,string> res = individual.getProfessionalByLocation(mapwithlocation);
                    //MessageBox.Show(res.Count.ToString());
                    if (first is not null)
                    {
                        first.Inlines.Add(new Run(res.First().Key) { FontWeight = FontWeights.Bold });
                        first.Inlines.Add(new LineBreak());
                        first.Inlines.Add(new Run(mapwithjob[res.First().Key]));
                        res.Remove(res.First().Key);
                    }
                    else first.Inlines.Clear();
                    if (res.Count > 0 && second is not null)
                    {
                        second.Inlines.Add(new Run(res.First().Key) { FontWeight = FontWeights.Bold });
                        second.Inlines.Add(new LineBreak());
                        second.Inlines.Add(new Run(mapwithjob[res.First().Key]));
                        res.Remove(res.First().Key);
                    }
                    else second.Inlines.Clear();
                    if (res.Count > 0 && third is not null)
                    {
                        third.Inlines.Add(new Run(res.First().Key) { FontWeight = FontWeights.Bold });
                        third.Inlines.Add(new LineBreak());
                        third.Inlines.Add(new Run(mapwithjob[res.First().Key]));
                        res.Remove(res.First().Key);
                    }
                    else third.Inlines.Clear();

                }
                else
                {
                    first.Inlines.Add(new Run("User or job not found !") { FontWeight = FontWeights.Bold });
                }
            }
        }

       
    }
}
