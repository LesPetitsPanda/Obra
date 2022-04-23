using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Utils
{
    public class RandomUtils
    {
        public static string GenerateFourNum()
        {
            string res = "";
            Random random = new Random();
            for(int _ = 0; _ < 4; _++)
            {
                res += random.Next(0,10);
            }
            return res;
        }
    }
}
