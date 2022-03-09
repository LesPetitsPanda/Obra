using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obra.Utils
{
    public class SerializerUtils
    {
        public static string writeToJSON(string type, string name, object data)
        {
            var loginMemory = new LoginMemory { 
            Type = type,
            Name = name,
            DataToRegister = data
            };
            string json = JsonSerializer.Serialize(loginMemory);
            return json;
        } // for example : bool islogin true => {"type":"bool", "name":islogin, "data":true} 
        public static void SerializeObject(string json, string filename)
        {
            File.WriteAllText(filename, json);
        }
        public static object DeserializeObject(string filename, string type, string name)
        {
            string json; 
            if (File.Exists(filename))
            {
                json= File.ReadAllText(filename);
            }
            else return null;

#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
            LoginMemory loginMemory = JsonSerializer.Deserialize<LoginMemory>(json);
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
            if (loginMemory.Name == name && loginMemory.Type == type)
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
            {
                return loginMemory.DataToRegister;
            }
            return null;
        }
    }
}
