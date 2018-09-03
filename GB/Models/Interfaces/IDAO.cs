using GB.Models.BO;
using GB.Models.GB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Models.Interfaces
{
    public interface IDAO<T>
    {
        string id_page { get; }
        GBConnexion connexion { get; set; }
        string form_combo_id { get; }
        string form_combo_libelle { get; }
        string form_name { get; }
        string form_combo_code { get; }
        void Ajouter(T obj, string id_utilisateur = null);
        void Modifier(T obj);
        void Supprimer(List<string> ids);
        List<T> Lister();
        T ObjectCode(string code);
        T ObjectId(string id);

        dynamic HTML_Select();
    }
}
