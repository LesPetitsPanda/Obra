using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Obra.TCPUtils
{
    public class TcpClientUtils
    {
        public TcpClient tcp;
        public Thread thrMessaging;
        public TcpClientUtils()
        {
        }


        public void SendMessage(string str, string UsertoSend)
        {
            Stream stm = tcp.GetStream();
            str = App.Username +":"+ UsertoSend + ": " + str;
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            stm.Write(ba, 0, ba.Length);
        }

        public void Receive()
        {
            Stream str = tcp.GetStream();
            while (true)
            {
                string res = "";
                byte[] bb = new byte[100];
                int k = str.Read(bb, 0, 100);
                for (int i = 0; i < k; i++)
                    res += Convert.ToChar(bb[i]);
                if (res != "")
                {
                    StreamWriter streamReader = new StreamWriter(@"DataConv\" +res.Split()[1]);
                    streamReader.Write(res);
                    streamReader.Close();
                }
            }

        }
        public void Connect()
        {
            tcp = new TcpClient();
            tcp.Connect(IPAddress.Parse("127.0.0.1"), 8001);
            Stream stm = tcp.GetStream();
            string str = App.Username + ":";
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            stm.Write(ba, 0, ba.Length);
            thrMessaging = new Thread(new ThreadStart(Receive));
            thrMessaging.IsBackground = true;
            thrMessaging.Start();

        }
        public void Close()
        {
            Thread.Sleep(500);
            tcp.Close();
        }
    }
}
