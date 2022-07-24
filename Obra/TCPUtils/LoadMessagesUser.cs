using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Obra.TCPUtils
{
    public class LoadMessagesUser
    {
        private static string path = "DataConv";

        public static void SerializeConversation(TextBlock textblock, string namefile)
        {
            string toSerialize = textblock.Text;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText(path + @"\" + namefile, toSerialize);
        }

        public static string DeSerializeConversation(string namefile) { 
        
            if(!File.Exists(path + @"\" + namefile))
            {
                return null;
            }
            return File.ReadAllText(path + @"\" + namefile);
        }
     
    }
    class TextContent
    {
        public string Data { get; set; } //the value of the data
    }
}
