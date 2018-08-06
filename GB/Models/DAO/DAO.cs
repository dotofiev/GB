using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Models.DAO
{
    public interface DAO
    {
        string id_page { get; }
        string context_id { get; set; }
        long id_utilisateur { get; set; }
        string form_combo_id { get; }
        string form_combo_libelle { get; }
        string form_name { get; }
        string form_combo_code { get; }

        dynamic HTML_Select();
    }
}
