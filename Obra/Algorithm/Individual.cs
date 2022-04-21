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
        private string _ipLocation;
      
        public ProfileType Type { get => _profileType; set => _profileType = value; }
     
        public string IpLocation { get => _ipLocation; set => _ipLocation = value; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public (int, int) Coord { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Individual(string iplocation)
        {
            _ipLocation = iplocation;
            _profileType = ProfileType.Individual;
        }

        //get allProfessionalLocation/Username without sort
        public Dictionary<string,string> getAllProfessionalLocation()
        {  return App.ConnectUtility.getDataOfColumnMatchUsername(mySQLConnectio.RowType.LOCATION, true); }

        //get allProfessionalLocation with sort by Location
        public Dictionary<string,string> getProfessionalByLocation(Dictionary<string,string> allProfession)
        {
            int i = 0;
            Dictionary<string,string> result = new Dictionary<string,string>();

            while(i < getAllProfessionalLocation().Count)
            {
                KeyValuePair<string, string> keyValuePair = DictionaryUtils.FirstKeyLocation(allProfession, _ipLocation);
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
                KeyValuePair<string, string> keyValuePair = DictionaryUtils.FirstKeyLocation(allProfession, _ipLocation);
                result.Append(keyValuePair);
                allProfession.Remove(keyValuePair.Key);
                i++;
            }
            return DictionaryUtils.ChangeStringValueInInt(result);
        }

        public Dictionary<string, string> getNameJobMatchingUsername(string job)
        {
            Dictionary<string ,string> result = new Dictionary<string ,string>();
           foreach(var val in mySQLConnectio.SQLConnectUtility.getName(job, App.ConnectUtility.conn))
            {
                result.Add(val, job);
            }
            return result;
        }
    }
}
