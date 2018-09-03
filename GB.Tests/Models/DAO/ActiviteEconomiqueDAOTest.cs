using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB.Models.DAO;
using GB.Models.Entites;
using GB.Models.BO;
using GB.Models.GB;
using GB.Models.Interfaces;
using System.Collections.Generic;

namespace GB.Tests.Models.DAO
{
    [TestClass]
    public class ActiviteEconomiqueDAOTest : IDAOTest<ActiviteEconomique>
    {
        // -- Paramètre de test -- //
        private GBConnexion con { get; set; }
        private BO obj { get; set; }
        private IDAO<ActiviteEconomique> dao { get; set; }

        [TestMethod]
        public void AjouterTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("test", "test");
            this.obj = new ActiviteEconomique()
            {
                code = "test",
                libelle_en = "test",
                libelle_fr = "test",
                date_creation = DateTime.Now.Ticks
            };
            this.dao = new ActiviteEconomiqueDAO(this.con);

            // -- Execution de la méthode à tester -- //
            this.dao.Ajouter(this.obj);

            // -- Test du résultat -- //
            Assert.IsNotNull(dao.ObjectCode(obj.code));
        }

        public void ListerTest()
        {
            throw new NotImplementedException();
        }

        public void ModifierTest()
        {
            throw new NotImplementedException();
        }

        public void ObjectCodeId()
        {
            throw new NotImplementedException();
        }

        public void ObjectCodeTest()
        {
            throw new NotImplementedException();
        }

        public void SupprimerTest()
        {
            throw new NotImplementedException();
        }
    }
}
