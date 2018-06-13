using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.Static
{
    public static class AppSettings
    {
        public static string VERSION_BUILD { get { return System.Configuration.ConfigurationManager.AppSettings["VERSION_BUILD"]; } }
    }
}