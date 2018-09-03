using GB.Models.BO;
using GB.Models.GB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Models.Interfaces
{
    public interface IDAOTest<T>
    {
        void AjouterTest();
        void ModifierTest();
        void SupprimerTest();
        void ObjectCodeTest();
        void ObjectCodeId();
        void ListerTest();
    }
}
