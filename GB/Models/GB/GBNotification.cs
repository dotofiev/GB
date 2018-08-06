using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace GB.Models.GB
{
    public class GBNotification
    {
        public string titre { get; set; }
        public short type { get; set; }
        public string message { get; set; }
        public object donnee { get; set; }
        public Boolean est_echec { get; set; }
        public dynamic dynamique { get; set; }

        public GBNotification() { }

        public GBNotification(string message, Boolean est_echec)
        {
            this.titre = "Information";
            this.type = Convert.ToInt16(
                                (est_echec) ? 3
                                            : 1
                                );
            this.message = (!est_echec) ? message
                                        : message.Contains(GBException.marqueur) ? message.Replace(GBException.marqueur, string.Empty)
                                                                                 : message;
            this.est_echec = est_echec;
            this.donnee = null;
            this.dynamique = new ExpandoObject();
        }
        public GBNotification(string message, Boolean est_echec, short type)
        {
            this.titre = "Information";
            this.type = type;
            this.message = (!est_echec) ? message
                                        : message.Contains(GBException.marqueur) ? message.Replace(GBException.marqueur, string.Empty)
                                                                                 : message;
            this.est_echec = est_echec;
            this.donnee = null;
            this.dynamique = new ExpandoObject();
        }
        public GBNotification(Boolean est_echec)
        {
            this.titre = "Information";
            this.type = Convert.ToInt16(
                                (est_echec) ? 3
                                            : 1
                                );
            this.message = (!est_echec) ? App_Lang.Lang.Successful + "!"
                                        : App_Lang.Lang.Error_message_notification;
            this.est_echec = est_echec;
            this.donnee = null;
            this.dynamique = new ExpandoObject();
        }
        public GBNotification(object donnee)
        {
            this.titre = "Information";
            this.type = 1;
            this.message = App_Lang.Lang.Successful + "!";
            this.est_echec = false;
            this.donnee = donnee;
            this.dynamique = new ExpandoObject();
        }
        public GBNotification(object donnee, string message)
        {
            this.titre = "Information";
            this.type = 1;
            this.message = message;
            this.est_echec = false;
            this.donnee = donnee;
            this.dynamique = new ExpandoObject();
        }
    }
}