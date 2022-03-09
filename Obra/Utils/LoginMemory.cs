using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Utils
{
    internal class LoginMemory
    {
        public string Type { get; set; }//type of data (string, bool)
        public string Name { get; set; }
        public object DataToRegister { get; set; } //the value of the data
    }
}
