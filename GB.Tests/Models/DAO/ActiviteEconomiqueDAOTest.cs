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
        private ActiviteEconomique obj { get; set; }
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

        [TestMethod]
        public void ListerTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("test", "test");
            this.dao = new ActiviteEconomiqueDAO(this.con);

            // -- Test du résultat -- //
            Assert.IsTrue(this.dao.Lister().Count != 0);
        }

        [TestMethod]
        public void ModifierTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("test", "test");
            this.obj = new ActiviteEconomique()
            {
                id = "test",
                code = "test",
                libelle_en = "test_modifier",
                libelle_fr = "test_modifier",
                date_creation = DateTime.Now.Ticks
            };
            this.dao = new ActiviteEconomiqueDAO(this.con);

            // -- Execution de la méthode à tester -- //
            this.dao.Modifier(this.obj as ActiviteEconomique);

            // -- Réccupération de l'objet modifié -- //
            ActiviteEconomique obj_updated = this.dao.ObjectCode(this.obj.code);

            // -- Test du résultat -- //
            Assert.IsTrue(obj_updated.Equals(this.obj));
        }

        [TestMethod]
        public void ObjectCodeId()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("test", "test");
            this.dao = new ActiviteEconomiqueDAO(this.con);
            string id = "1";

            // -- Test du résultat -- //
            Assert.IsNotNull(this.dao.ObjectId(id));
        }

        [TestMethod]
        public void ObjectCodeTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("test", "test");
            this.dao = new ActiviteEconomiqueDAO(this.con);
            string code = "1";

            // -- Test du résultat -- //
            Assert.IsNotNull(this.dao.ObjectId(code));
        }

        [TestMethod]
        public void SupprimerTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("test", "test");
            this.dao = new ActiviteEconomiqueDAO(this.con);
            string id = "test";

            // -- réccupérer la taille de départ -- //
            int taille_depart = this.dao.Lister().Count;

            // -- Supprimer l'element -- //
            this.dao.Supprimer(new List<string> { id });

            // -- Taille arrivé -- //
            int taille_arrivee = this.dao.Lister().Count;

            // -- Test du résultat -- //
            Assert.IsTrue((taille_depart - taille_arrivee) == 1 && this.dao.ObjectCode(id) == null);
        }
    }
}
