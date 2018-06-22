using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public abstract class GBBO
    {
        // -- Privé -- //
        protected long _id;
        
        // -- Public -- //
        public long id { get { return this._id; } } 
        public string code { get; set; }
        public string libelle_en { get; set; }
        public string libelle_fr { get; set; }
    }
}