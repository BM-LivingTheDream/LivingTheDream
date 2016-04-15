using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabrikamFiber.Web.SeleniumTests
{
    public class Helper
    {
       public static Uri WebUrl
        {
            get
            {
                var baseuri = ConfigurationManager.AppSettings["weburi"];
                if (baseuri == null)
                {
                    throw new NullReferenceException("No baseuri definded");
                }
                return new Uri(baseuri);
            }
        }
    }
}
