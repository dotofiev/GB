using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB.Models.DAO;
using GB.Models.Entites;
using GB.Models.BO;
using GB.Models.GB;

namespace GB.Tests.Models.DAO
{
    [TestClass]
    public class DeviseDAOTest
    {
        [TestMethod]
        public void AjouterTest()
        {
            // -- Classe à tester -- //
            DeviseDAO deviseDAO = new DeviseDAO(new GBConnexion(string.Empty, string.Empty));

            // -- Parametres de test -- //
            Devise obj = new Devise()
            {
                code = "zzz",
                devise_actuelle = false,
                date_creation = DateTime.Now.Ticks,
                signe = "zzz",
                libelle = "zzz"
            };

            // -- Execution de la méthode à tester -- //
            deviseDAO.Ajouter(obj);

            // -- Test du résultat -- //
            Assert.IsNotNull(DeviseDAO.ObjectCode(obj.code));
        }

        [TestMethod]
        public void ActifTest()
        {
            var donnee = DeviseDAO.Actif();

            Assert.IsTrue(donnee?.devise_actuelle ?? false);
        }
    }
}
