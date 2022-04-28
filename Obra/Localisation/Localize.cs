using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.IO;

namespace Obra.Localisation
{
    public class Localize
    {
        public static string GetLocationByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
            }
            catch (Exception)
            {
                ipInfo.Country = null;
            }

            return ipInfo.Loc;
        }

        public static string GetCityByIp(string ip)
        {

            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
            }
            catch (Exception)
            {
                ipInfo.Country = null;
            }

            return ipInfo.City;
        }
        public static double GetDistanceBetween(string loc1, string loc2)
        {
            string[] loc1A = loc1.Split(",");
            string[] loc2A = loc2.Split(",");
            double lat1 = Convert.ToDouble(loc1A[0]);
            double long1 = Convert.ToDouble(loc1A[1]);
            double lat2 = Convert.ToDouble(loc2A[0]);
            double long2 = Convert.ToDouble(loc2A[1]);
            GeoCoordinate pin1 = new GeoCoordinate(lat1, long1);
            GeoCoordinate pin2 = new GeoCoordinate(lat2, long2);
            return pin1.GetDistanceTo(pin2)/1000;
        }

        public static string GetIpOfUser()
        {
            string address = "";
            if(Utils.SerializerUtils.DeserializeObject("userip", "string", "ip") != null)
            {
                return (string)Utils.SerializerUtils.DeserializeObject("usserip", "string", "ip");
            }
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);
            Utils.SerializerUtils.SerializeObject(Utils.SerializerUtils.writeToJSON("userip", "string", "ip"), address);
            return address;
        }
    }
}
