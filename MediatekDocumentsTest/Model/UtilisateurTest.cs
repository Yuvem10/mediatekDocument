using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class UtilisateurTest
    {
        private const string identifiant = "identifiant";
        private const string password = "password";
        private const string nomService = "nomService";
        private static Utilisateur utilisateur = new Utilisateur(identifiant, password, nomService);

        [TestMethod]
        public void utilisateurTest()
        {
            Assert.AreEqual(identifiant, utilisateur.identifiant);
            Assert.AreEqual(password, utilisateur.password);
            Assert.AreEqual(nomService, utilisateur.nomService);
        }
    }
}
