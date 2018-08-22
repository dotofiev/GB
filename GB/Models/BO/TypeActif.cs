﻿using GB.Models.BO;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class TypeActif : BO, IBO<object>
    {
        public long date_creation { get; set; }
        
        public TypeActif(string id)
        {
            this.id = id;
        }

        public TypeActif() { }

        public void Crer_Id()
        {
            this.id = (Program.db.types_actif.Count + 1).ToString();
        }

        public object ToEntities()
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