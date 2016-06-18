using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanIPlay
{
    public class Website
    {

        static string GOOGLE = "http://www.google.ca";
        static string RIOT1 = "104.160.131.1";
        static string RIOT2 = "104.160.131.3";

        public string Name { get; set; }
        public string URL { get; set; }

        public Website(string name, string url)
        {
            Name = name;
            URL = url;
        }

        //public static void InitDictionary()
        //{
        //    listOfWebsites = new Dictionary<string, string>();
        //    listOfWebsites.Add("GOOGLE", GOOGLE);
        //    listOfWebsites.Add("RIOT1", RIOT1);
        //    listOfWebsites.Add("RIOT2", RIOT2);

        //}

        //public static Dictionary<string,string> listOfWebsites{ get; set; }
    }
}
