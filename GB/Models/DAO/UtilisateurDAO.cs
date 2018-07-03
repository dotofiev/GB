using GB.Models.BO;
using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.DAO
{
    public class UtilisateurDAO : GBDAO
    {
        public static bool Existe(string compte, string mot_de_passe)
        {
            try
            {
                // -- Vérifier l'existance -- //
                return
                    Program.db.utilisateurs.Exists(l => l.compte == compte && l.mot_de_passe == mot_de_passe);
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }

        public static Utilisateur Object(string compte, string mot_de_passe)
        {
            try
            {
                // -- Vérifier l'existance -- //
                return
                    Program.db.utilisateurs.FirstOrDefault(l => l.compte == compte && l.mot_de_passe == mot_de_passe);
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Vérifier la nature de l'exception -- //
                if (!GBException.Est_GBexception(ex))
                {
                    // -- Log -- //
                    GBClass.Log.Error(ex);

                    // -- Renvoyer l'exception -- //
                    throw new GBException(App_Lang.Lang.Error_message_notification);
                }
                else
                {
                    // -- Renvoyer l'exception -- //
                    throw new GBException(ex.Message);
                }
            }
            #endregion
        }
    }
}