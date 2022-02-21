using Obra.SQLTools.ProfessionalAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Algorithm
{
    internal class ProfessionalAlgorithm : IProfile
    {
        private ProfileType _profileType;
        private string _name;
        private string _ipLocation;
        private (int, int) _coord;
        private int _rate;
        public ProfileType Type { get => _profileType; set => _profileType = value; }
        public string Name { get => _name; set => _name = value; }
        public string IpLocation { get => _ipLocation; set => _ipLocation = value; }
        public (int, int) Coord { get => _coord; set => _coord = value; }
        public int Rate { get => _rate; set => _rate = value; }

        public ProfessionalAlgorithm(string name, string iplocation, (int, int) coord)
        {
            _name = name;
            _ipLocation = iplocation;
            _coord = coord;
            _profileType = ProfileType.Individual;
            _rate = -1;
        }

        public bool 
        

    }
}
