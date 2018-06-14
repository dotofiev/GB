using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState;

namespace GB.Models.Helper
{
    public class LangHelper
    {
        protected HttpSessionState session;

        //constructor 
        public LangHelper(HttpSessionState httpSessionState)
        {
            session = httpSessionState;
        }

        // Properties
        public static int CurrentCulture
        {
            get
            {
                return (Thread.CurrentThread.CurrentUICulture.Name == GB_Enum_Langue.Francais) ? 1
                                                                                               : 0;
            }
            set
            {
                Thread.CurrentThread.CurrentUICulture = (value == 0) ? new CultureInfo(GB_Enum_Langue.Anglais)
                                                                     : (value == 1) ? new CultureInfo(GB_Enum_Langue.Francais)
                                                                                    : CultureInfo.InvariantCulture;

                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            }
        }
    }
}