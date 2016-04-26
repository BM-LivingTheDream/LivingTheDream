using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FabrikamFiber.Web.Helpers
{
    public class FeatureFlag
    {
        public const string GENERATETESTDATA = "GENERATETESTDATA";

        public static bool IsFlagSet(string flag)
        {
            var retValue = false;
            if (string.IsNullOrEmpty(flag) == false)
            {
                try
                {
                    bool.TryParse(System.Configuration.ConfigurationManager.AppSettings[flag], out retValue);

                }
                catch (System.Configuration.ConfigurationErrorsException)
                { }
            }
            return retValue;
        }
    }
}
