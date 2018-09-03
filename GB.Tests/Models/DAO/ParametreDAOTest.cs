using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB.Models.Interfaces;
using GB.Models.BO;
using GB.Models.Entites;
using GB.Models.GB;
using GB.Models.DAO;

namespace GB.Tests.Models.DAO
{
    [TestClass]
    public class ParametreDAOTest : IDAOTest<GB.Models.BO.Parametre>
    {
        // -- Paramètre de test -- //
        GBConnexion con { get; set; }
        GB.Models.BO.Parametre obj { get; set; }
        IDAO<GB.Models.BO.Parametre> dao { get; set; }

        [TestMethod]
        public void AjouterTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ListerTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ModifierTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("tes", "tes");
            this.obj = new GB.Models.BO.Parametre()
            {
                id = "tes",
                code = "tes",
                libelle = "test_modifier",
                //signe = "tes_udt",
                //devise_actuelle = false,
                date_creation = DateTime.Now.Ticks
            };
            this.dao = new ParametreDAO(this.con);

            // -- Execution de la méthode à tester -- //
            this.dao.Modifier(this.obj);

            // -- Réccupération de l'objet modifié -- //
            GB.Models.BO.Parametre obj_updated = this.dao.ObjectCode(this.obj.code);

            // -- Test du résultat -- //
            Assert.IsTrue(obj_updated.Equals(this.obj));
        }

        [TestMethod]
        public void ObjectCodeId()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ObjectCodeTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SupprimerTest()
        {
            throw new NotImplementedException();
        }
    }
}
