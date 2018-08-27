using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class AutoriteSignature : BO, IBO<object>
    {
        public long montant_signature { get; set; }
        public long limite_decouvert_client { get; set; }
        public long debit_max_client { get; set; }
        public long credit_max_client { get; set; }
        public long montant_max_ligne_credit { get; set; }
        public long montant_limite_pret { get; set; }

        public AutoriteSignature(string id)
        {
            this.id = id;
        }

        public AutoriteSignature() { }

        public void Crer_Id()
        {
            this.id = (Program.db.autorites_signature.Count + 1).ToString();
        }

        public object ToEntities(Dictionary<string, object> parametres = null)
        {
            throw new NotImplementedException();
        }

        public void FromEntities(object entitie)
        {
            throw new NotImplementedException();
        }

        public void ModifyEntities(object entitie)
        {
            throw new NotImplementedException();
        }
    }
}