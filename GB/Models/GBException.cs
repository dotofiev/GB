using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models
{
    public class GBException : Exception
    {
        public static string marqueur = "_afficher_";

        public override string Message
        {
            get
            {
                return marqueur + base.Message;
            }
        }

        // -- Constructeur -- //
        public GBException(string message) : base(message) { }

        // -- Vérifier que l'exception est contient le marqueur -- //
        public static Boolean Est_GBexception(Exception ex)
        {
            return
                ex?.Message?.Contains(GBException.marqueur) ?? true;
        }
    }
}