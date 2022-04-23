using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
    /// Logique d'interaction pour MessagePart.xaml
    /// </summary>
    public partial class MessagePart : Page
    {
        private TcpClient tcp;
        private StreamWriter SwSender;
        private StreamReader SrReciever;
        private Thread thrMessaging;
        private delegate void NewMessageCallBack(string strMessage);
        public MessagePart()
        {
            InitializeComponent();
            Loaded += MakeConnexion;
            Unloaded += Window_Closing;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            tcp.Close();
        }
        private void Window_Closing(object sender, RoutedEventArgs e)
        {
            tcp.Close();
            Thread.CurrentThread.Join();
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
            ns.Navigate(new Uri("Pages/Profils.xaml", UriKind.Relative));
        }

        private void MakeConnexion(object sender, EventArgs e)
        {
            Connect();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Keyboard.ClearFocus();
                SendMessage(entermessage.Text);
                entermessage.Clear();
                
            }
        }

        private void SendMessage(string str)
        {
            Stream stm = tcp.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");

            stm.Write(ba, 0, ba.Length);
            UpdateMessage(str);
            //Receive();
        }

        private void Receive()
        {
            SrReciever = new StreamReader(tcp.GetStream());
            while (true)
            {
                
                string response = SrReciever.ReadLine();
                content_messages.Dispatcher.Invoke(new NewMessageCallBack(this.UpdateMessage), new object[] { "testtt" });
            }
        }

        private void Connect()
        {
            tcp = new TcpClient();
            UpdateMessage("connecting");
            tcp.Connect(IPAddress.Parse("127.0.0.1"), 8001);
            UpdateMessage("Connected");
            thrMessaging = new Thread(new ThreadStart(Receive));
            thrMessaging.IsBackground = true;
            thrMessaging.Start();

        }
        private void UpdateMessage(string str)
        {
            content_messages.Text += str + "\n";
            messages.ScrollToBottom();
        }
    }
}
