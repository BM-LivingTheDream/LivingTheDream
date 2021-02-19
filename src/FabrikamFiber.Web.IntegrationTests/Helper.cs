using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FabrikamFiber.Web.IntegrationTests
{
    public class Helper
    {
        public static WebClient WebClient()
        {
            var wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            wc.UseDefaultCredentials = true;
            return wc;
        }

        public static dynamic ParseJson(string data, object dummyObject)
        {
            // do a bit a parsing to make asserts easier
            return JsonConvert.DeserializeAnonymousType(data, dummyObject);
        }

        public static Uri WebUrl(string path)
        {
            var baseuri = ConfigurationManager.AppSettings["weburi"];
            if (baseuri == null)
            {
                throw new NullReferenceException("No baseuri definded");
            }
            return new Uri(string.Format("{0}{1}", baseuri, path));
        }
    }
}
