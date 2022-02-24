using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Algorithm.Utils
{
    internal class DictionaryUtils
    {
        //return the first professional user/iplocation of the Dictionnary
        public static KeyValuePair<string,string> FirstKeyLocation(Dictionary<string,string> keyValuePairs)
        {
            KeyValuePair<string,string> data = new KeyValuePair<string,string>();
            foreach(KeyValuePair<string,string> pair in keyValuePairs)
                if(CompareLocationFirstWithSecond(pair.Value, data.Value))
                {
                    data = pair;
                }
            return data;
        }
        //Si IP1 > IP2 return true else false
        public static bool CompareLocationFirstWithSecond(string ip1, string ip2)
        {
            //à implementer !!!!!!
            return true;
        }
        public static KeyValuePair<string,int> FirstKeyRate(Dictionary<string,int> keyValuePairs) {

            KeyValuePair<string, int> data = new();
            foreach (KeyValuePair<string, int> pair in keyValuePairs)
                if (pair.Value >data.Value )
                {
                    data = pair;
                }
            return data;
        }
        public static Dictionary<string,int> ChangeStringValueInInt(Dictionary<string,string> dictio)
        {
            Dictionary<string, int> value = new();
            foreach (KeyValuePair<string,string> key in dictio)
            {
                value.Add(key.Key, Int32.Parse(key.Value));
            }
            return value;
        }

    }
}

