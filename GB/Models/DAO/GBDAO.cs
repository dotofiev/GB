﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Models.DAO
{
    public interface GBDAO
    {
        string form_combo_id { get; }
        string form_combo_libelle { get; }

        void HTML_Select(ref string select_code, ref string select_libelle);
    }
}
