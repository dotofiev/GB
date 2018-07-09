using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class GBFichier
    {
        public byte[] fichier { get; set; }
        public string libelle { get; set; }

        public GBFichier()
        {
            this.fichier = new byte[] { };
        }
    }
}