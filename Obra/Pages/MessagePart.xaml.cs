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

        private TcpClient client;
        const int port = 8001;
        const string address = "192.168.1.25";
        int count = 3;
        private delegate void NewMessageCallBack(string strMessage);
        public MessagePart()
        {
            InitializeComponent();
            Loaded += MakeConnexion;
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
            if (count == 0)
            {
                content_messages.Text += "\n Connection Problem";
                messages.ScrollToBottom();
            }
            else
            {
                try
                {
                    string userName = "Valentin";
                    string message = "First Message";

                    if (string.IsNullOrWhiteSpace(message))
                    {
                        MessageBoxResult mbr = MessageBox.Show("Error WhiteSpace!");
                    }
                    else
                    {
                        Thread t = new Thread(() => Connect(userName, message, address, port));
                        t.Start();

                    }
                }
                catch (FormatException p)
                {
                    MessageBoxResult mbr = MessageBox.Show("ERROR!");
                    return;
                    throw;
                }
            }

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Keyboard.ClearFocus();
                Send(client.GetStream(), "Valentin", entermessage.Text);
            }
        }

        private void Connect(string userName, string msg, string ip, int port)
        {
            // header = 0;
            client = new TcpClient();

            // Client connects to the server on the specified ip and port.
            try
            {
                client.Connect(ip, port);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                MessageBoxResult mbr = MessageBox.Show("IP was empty.");
                return;
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                MessageBoxResult mbr = MessageBox.Show("Port isn't within the allowed range.");
                return;
                throw;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                MessageBoxResult mbr = MessageBox.Show("Couldn't access the socket.");
                return;
                throw;
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                MessageBoxResult mbr = MessageBox.Show("TCP Client is closed.");
                return;
                throw;
            }

            // Get client stream for reading and writing.
            // Using is a try finally, if an exception occurs it disposes of the stream.
            NetworkStream stream = client.GetStream();

            Send(stream, userName, msg);
            while (true)
            {
                if (client.Connected)
                {
                    Receive(stream);
                }
                else
                {
                    stream.Dispose();
                    client.Close();
                    client.Dispose();
                    Thread.CurrentThread.Join();
                }
            }
        }
        private void Send(NetworkStream stream, string userName, string message)
        {
            message = String.Format("{0}: {1}", userName, message);
            byte[] data = Encoding.Unicode.GetBytes(message);
            try
            {
                if (stream.CanWrite)
                {
                    stream.Write(data, 0, data.Length);
                    this.Dispatcher.Invoke(() =>
                    {
                        content_messages.Text += "\n" + message;
                        messages.ScrollToBottom();
                    });
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                MessageBoxResult mbr = MessageBox.Show("The message size is too big for the buffer.");
                return;
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                MessageBoxResult mbr = MessageBox.Show("An error occurred when accessing the socket.");
                return;
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                MessageBoxResult mbr = MessageBox.Show("There was a failure reading from the network.");
                return;
            }
        }

        private void Receive(NetworkStream ns)
        {

            byte[] data = new byte[64];
            string message;
            try
            {
                if (ns.CanRead)
                {
                    if (client.Connected)
                    {
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0;
                        do
                        {
                            bytes = ns.Read(data, 0, data.Length);
                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (ns.DataAvailable);

                        message = builder.ToString();
                        message = String.Format("Сервер: {0}", message);
                        this.Dispatcher.Invoke(() =>
                        {
                          /* content_messages.Text += "\n" + message;
                            messages.ScrollToBottom();
                            if (builder.ToString() == "NACK")
                            {
                                count--;
                                message = String.Format("У вас осталось {0} попыток", count);
                                content_messages.Text += "\n" + message;
                                messages.ScrollToBottom();
                            };
                        */});
                    }
                    else
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            content_messages.Text += "\n not connected anymore";
                            messages.ScrollToBottom();
                        });
                    }
                }
                else
                {
                    //return null;
                }
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                client.Close();
                //MessageBoxResult mbr = MessageBox.Show("TCP Client is closed.");
                //return null;

            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                MessageBoxResult mbr = MessageBox.Show("There was a failure reading from the network.");
                client.Close();
                //return null;
            }
        }
    }
}
