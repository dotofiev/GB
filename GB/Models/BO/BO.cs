﻿using GB.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public abstract class BO
    {
        // -- Public -- //
        public string id { get; set; } 
        public string code { get; set; }
        public string libelle_en { get; set; }
        public string libelle_fr { get; set; }
        public string libelle { get; set; }
    }
}