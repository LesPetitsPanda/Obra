using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Algorithm
{
    internal interface IProfile
    {
        ProfileType Type { get; set; }
        string Name { get; set; }
        string IpLocation { get; set; }
        (int,int) Coord { get; set; }

    }
}
