﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB.Controllers;
using System.Web.Mvc;
using GB.Models.GB;
using System.Collections.Generic;
using GB.Models.Static;

namespace GB.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        // -- Paramètre de test -- //
        private GBConnexion con { get; set; }
        private HomeController controller { get; set; }

        [TestMethod]
        public void ConnexionTest()
        {
            // -- Controlleur à tester -- //
            this.con = new GBConnexion("test", "test");
            this.controller = new HomeController();
            this.controller.con = this.con;

            // -- Parametres de test -- //
            string compteTest = "99999", mot_de_passeTest = "admin";

            // -- Execution de la méthode à tester -- //
            GBNotification donnee = GBConvert.To_Object<GBNotification>(
                                        ((controller.Connexion(compteTest, mot_de_passeTest) as JsonResult).Data as Dictionary<string, object>)["notification"]
                                    );

            // -- Test du résultat -- //
            Assert.IsTrue(donnee.est_echec == false);
        }
    }
}