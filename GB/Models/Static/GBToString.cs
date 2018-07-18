using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GB.Models.Static
{
    public static class GBToString
    {
        public static string Oui_Non(bool donnee)
        {
            return
                donnee ? App_Lang.Lang.Yes
                       : App_Lang.Lang.No;
        }

        public static string Activer_Desactiver(bool donnee)
        {
            return
                donnee ? App_Lang.Lang.Activated
                       : App_Lang.Lang.Disabled;
        }

        public static string MontantToString(object value)
        {
            return
                Convert.ToDecimal(value)
                .ToString(
                    "C",
                    new NumberFormatInfo()
                    {
                        CurrencyGroupSeparator = " ",
                        CurrencySymbol = string.Empty,
                        CurrencyDecimalDigits = 0
                        //CurrencyPositivePattern = 3,
                        //CurrencyNegativePattern = 8
                    }
                );
        }
    }
}