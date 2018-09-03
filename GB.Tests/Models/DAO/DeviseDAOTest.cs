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
    public class DeviseDAOTest : IDAOTest<Devise>
    {
        // -- Paramètre de test -- //
        GBConnexion con { get; set; }
        Devise obj { get; set; }
        IDAO<Devise> dao { get; set; }

        [TestMethod]
        public void AjouterTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("tes", "tes");
            this.obj = new Devise()
            {
                code = "tes",
                libelle = "tes",
                signe = "tes",
                devise_actuelle = false,
                date_creation = DateTime.Now.Ticks
            };
            this.dao = new DeviseDAO(this.con);

            // -- Execution de la méthode à tester -- //
            this.dao.Ajouter(this.obj as Devise);

            // -- Test du résultat -- //
            Assert.IsNotNull(dao.ObjectCode(obj.code));
        }

        [TestMethod]
        public void ListerTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("tes", "tes");
            this.dao = new DeviseDAO(this.con);

            // -- Test du résultat -- //
            Assert.IsTrue(this.dao.Lister().Count != 0);
        }

        [TestMethod]
        public void ModifierTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("tes", "tes");
            this.obj = new Devise()
            {
                id = "tes",
                code = "tes",
                libelle = "test_modifier",
                signe = "tes_udt",
                devise_actuelle = false,
                date_creation = DateTime.Now.Ticks
            };
            this.dao = new DeviseDAO(this.con);

            // -- Execution de la méthode à tester -- //
            this.dao.Modifier(this.obj as Devise);

            // -- Réccupération de l'objet modifié -- //
            Devise obj_updated = this.dao.ObjectCode(this.obj.code);

            // -- Test du résultat -- //
            Assert.IsTrue(obj_updated.Equals(this.obj));
        }

        [TestMethod]
        public void ObjectCodeId()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("tes", "tes");
            this.dao = new DeviseDAO(this.con);
            string id = "aaa";

            // -- Test du résultat -- //
            Assert.IsNotNull(this.dao.ObjectId(id));
        }

        [TestMethod]
        public void ObjectCodeTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("tes", "tes");
            this.dao = new DeviseDAO(this.con);
            string code = "aaa";

            // -- Test du résultat -- //
            Assert.IsNotNull(this.dao.ObjectId(code));
        }

        [TestMethod]
        public void ActifTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("tes", "tes");
            this.dao = new DeviseDAO(this.con);

            // -- Tester l'existance d'une devise actuelle -- //
            Assert.IsTrue((this.dao as DeviseDAO).Actif()?.devise_actuelle ?? false);
        }

        [TestMethod]
        public void SupprimerTest()
        {
            // -- Parametres de test -- //
            this.con = new GBConnexion("tes", "tes");
            this.dao = new DeviseDAO(this.con);
            string id = "tes";

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
