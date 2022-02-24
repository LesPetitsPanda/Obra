using Obra.Algorithm.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Algorithm
{
    internal class Individual : IProfile
    {
        private ProfileType _profileType;
        private string _name;
        private string _ipLocation;
        private (int, int) _coord;
        public ProfileType Type { get => _profileType; set => _profileType = value; }
        public string Name { get => _name; set => _name = value; }
        public string IpLocation { get => _ipLocation; set => _ipLocation = value; }
        public (int, int) Coord { get => _coord; set => _coord = value; }

        public Individual(string name, string iplocation, (int,int) coord)
        {
            _name = name;
            _ipLocation = iplocation;
            _coord = coord;
            _profileType = ProfileType.Individual;
        }

        //get allProfessionalLocation/Username without sort
        public Dictionary<string,string> getAllProfessionalLocation()
        {  return App.ConnectUtility.getDataOfColumnMatchUsername(mySQLConnectio.RowType.LOCATION, true); }

        //get allProfessionalLocation with sort by Location
        public Dictionary<string,string> getProfessionalByLocation()
        {
            int i = 0;
            Dictionary<string,string> allProfession = getAllProfessionalLocation();
            Dictionary<string,string> result = new Dictionary<string,string>();

            while(i < getAllProfessionalLocation().Count)
            {
                KeyValuePair<string, string> keyValuePair = DictionaryUtils.FirstKeyLocation(allProfession);
                result.Append(keyValuePair);
                allProfession.Remove(keyValuePair.Key);
                i++;
            }
            return result;
        }
        public Dictionary<string,int> getProfessionalByRate()
        {
              int i = 0;
            Dictionary<string,string> allProfession = App.ConnectUtility.getDataOfColumnMatchUsername(mySQLConnectio.RowType.RATE, true);
            Dictionary<string,string> result = new Dictionary<string,string>();

            while(i < getAllProfessionalLocation().Count)
            {
                KeyValuePair<string, string> keyValuePair = DictionaryUtils.FirstKeyLocation(allProfession);
                result.Append(keyValuePair);
                allProfession.Remove(keyValuePair.Key);
                i++;
            }
            return DictionaryUtils.ChangeStringValueInInt(result);
        }
    }
}
