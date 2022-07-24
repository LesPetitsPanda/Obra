using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obra.Utils
{
    public class LastResearch
    {
        public static void WriteResearch(string name_to_write, string content)
        {
            if (!Directory.Exists("researchData"))
            {
                Directory.CreateDirectory("researchData");
            }
            SerializerUtils.SerializeObject(SerializerUtils.writeToJSON("string", name_to_write, content), @"researchData\research_" + DateTimeOffset.Now.ToUnixTimeSeconds());
        }
        public static Tuple<string, string> getInformation(string filename)
        {
            string json;
            if (File.Exists(filename))
            {
                json = File.ReadAllText(filename);
            }
            else return null;

#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
            LoginMemory loginMemory = JsonSerializer.Deserialize<LoginMemory>(json);

            if (loginMemory is not null)
            {
                return new Tuple<string, string>(loginMemory.Name, loginMemory.DataToRegister);
            }
            return null;
        }

        public static List<Tuple<string, string>> getThreeLastResearch()
        {
            List<string> allPath = new();
            foreach (var file in Directory.GetFiles("researchData"))
            {
                allPath.Add(file);
            }
            int K, L, I, J;
            for (I = allPath.Count - 2; I >= 0; I--)
            {
                for (J = 0; J <= I; J++)
                {
                    if (Int64.Parse(allPath[J + 1].Split('_')[1]) > Int64.Parse(allPath[J].Split('_')[1]))
                    {
                        string t = allPath[J + 1];
                        allPath[J + 1] = allPath[J];
                        allPath[J] = t;
                    }
                }
            }
            if (allPath.Count > 3)
            {
                allPath.RemoveRange(3, allPath.Count - 3);
            }
            List<Tuple<string, string>> res = new();
            foreach (var path in allPath)
            {
                res.Add(getInformation(path));
            }
            return res;
        }
    } 
}
