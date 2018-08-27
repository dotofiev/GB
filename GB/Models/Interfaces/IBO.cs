using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Models.Interfaces
{
    public interface IBO<T>
    {
        T ToEntities(Dictionary<string, object> parametres = null);
        void FromEntities(T entitie);
        void ModifyEntities(T entitie);
        void Crer_Id();
    }
}
