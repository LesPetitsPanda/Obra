using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obra.Utils
{
    public class MessageManagerUtils
    {
        public static bool isAlreadyMarked(string filename, string username)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            List<string> list = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filename));
            if (!list.Contains(username))
            {
                return false;
            }
            return true;
        }
        public static void AddMark(string filename, string username)
        {
            if (isAlreadyMarked(filename, username)) { return; }

            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, JsonSerializer.Serialize(new List<string> { username }));
            }
            else
            {
                List<string> list = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filename));
                list.Add(username);
                File.WriteAllText(filename, JsonSerializer.Serialize(list));
            }
        }

        public static List<string> getList(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }
            List<string> list = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filename));
            return list;
        }
    }
}
